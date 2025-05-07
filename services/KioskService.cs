using Microsoft.EntityFrameworkCore;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;
using GROCERYDISCOUNTBACKEND.MODELS;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class KioskService {
        private readonly AppsdevDBContext _db;
        public KioskService() => _db = AppsdevDBContext.Instance;
        public async Task<List<KioskDTO>> GetKiosksAsync() {
            return await _db.Kiosks
                .Select(res => new KioskDTO {
                    Username = res.Username
                })
                .ToListAsync();
        }
        public async Task RegisterKioskAsync(KioskModel kiosk) {
            using var transaction = await _db.Database.BeginTransactionAsync();
            
            try {
                await _db.Kiosks.AddAsync(kiosk);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Failed registering kiosk! Rolled back changes");
            }
        }
        public async Task UpdateKioskAsync(KioskDTO source, KioskModel updated) {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try {
                long? kioskID = await _db.Kiosks
                    .Where(kiosk => kiosk.Username == source.Username)
                    .Select(kiosk => (long?)kiosk.KioskID)
                    .FirstOrDefaultAsync();
                
                if (kioskID.HasValue) {
                    var updatedKiosk = updated;

                    updatedKiosk.KioskID = (long)kioskID;
                    _db.Update(updatedKiosk);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                } else {
                    await transaction.RollbackAsync();
                    throw new Exception("User not found!");
                }
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Error updating kiosk details! Rolled back changes");
            }
        }
        public async Task RemoveKioskAsync(KioskDTO kioskDTO) {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try {
                var kiosk = await _db.Kiosks
                    .FirstOrDefaultAsync(res => res.Username == kioskDTO.Username);
                
                if (kiosk != null) {
                    _db.Remove(kiosk);

                    await _db.SaveChangesAsync();
                    await _db.Database.ExecuteSqlRawAsync("EXEC reseedAll");
                    await transaction.CommitAsync();
                } else {
                    await transaction.RollbackAsync();
                    throw new Exception("Kiosk not found!");
                }
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Error removing kiosk!");
            }
        }
    }
}