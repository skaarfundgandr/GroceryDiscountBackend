using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class TransactionService {
        private readonly AppsdevDBContext _db;
        public TransactionService() => _db = AppsdevDBContext.Instance;

        public async Task<List<PurchaseHistoryViewDTO>> GetPurchaseHistory() {
            return await _db.PurchaseHistory
                .Select(res => new PurchaseHistoryViewDTO {
                    KioskID = res.Kiosk,
                    ProductName = res.ProductName,
                    Amount = res.Amount,
                    Date = res.Date
                })
                .ToListAsync();
        }
        public async Task PurchaseProductAsync(ProductDTO product, int amount) {
            try {
                var productNameParam = new SqlParameter("@productName", product.ProductName);
                var purchaseAmountParam = new SqlParameter("@amount", amount);

                await _db.Database
                    .ExecuteSqlRawAsync("EXEC purchaseProduct @productName, @amount", productNameParam, purchaseAmountParam);
            } catch {
                throw new Exception("Error purchasing product!");
            }
        }
        // TODO: Add logic to remove a purchase from history
    }
}