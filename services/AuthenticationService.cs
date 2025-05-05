//TODO:
using Microsoft.EntityFrameworkCore;
using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class AuthenticationService {
        private readonly AppsdevDBContext _db;
        public AuthenticationService(AppsdevDBContext db) => _db = db;

        public async Task<bool> Authenticate(String username, String password) {
            var user = await _db.Kiosks
                .Where(res => res.Username == username)
                .Where(res => res.Password == password)
                .Select(res => new KioskDTO {
                    Username = res.Username
                })
                .ToListAsync();
            
            if (user.Count > 1) {
                throw new Exception("Duplicate entries found!");
            } else if (user.Count == 0) {
                return false;
            } else {
                Console.WriteLine($"{user[0].Username} Logged in");
                return true;
            }
        }
    }
}