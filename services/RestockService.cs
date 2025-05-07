using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.MODELS;
using GROCERYDISCOUNTBACKEND.DTO;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class RestockService {
        private readonly AppsdevDBContext _db;

        public RestockService() => _db = AppsdevDBContext.Instance;

        public async Task<List<RestockHistoryViewDTO>> GetRestockHistoryViewAsync() {
            return await _db.RestockHistoryView
                .Select(res => new RestockHistoryViewDTO {
                    ProductName = res.ProductName,
                    Amount = res.Amount,
                    Date = res.Date
                })
                .ToListAsync();
        }
        public async Task RestockProductAsync(ProductDTO product, int amount) {
            try {
                var nameParam = new SqlParameter("@productName", product.ProductName);
                var restockAmountParam = new SqlParameter("@amount", amount);

                await _db.Database
                    .ExecuteSqlRawAsync("EXEC restockProduct @productName, @amount", nameParam, restockAmountParam);
            } catch {
                throw new Exception("Error restocking product!");
            }
        }
        // TODO: Add logic to remove restock
    }
}