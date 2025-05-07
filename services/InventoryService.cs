using Microsoft.EntityFrameworkCore;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;
using System.Data.SqlClient;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class InventoryService {
        private readonly AppsdevDBContext _db;

        public InventoryService() => _db = AppsdevDBContext.Instance;

        public async Task<List<InventoryProductsViewDTO>> GetInventoryProductsAsync() {
            return await _db.InventoryProducts
                .Select(res => new InventoryProductsViewDTO {
                    ProductName = res.ProductName,
                    Description = res.Description,
                    Category = res.Category,
                    Price = res.Price,
                    Quantity = res.Quantity,
                    Units = res.Units,
                    LastRestock = res.LastRestock
                })
                .ToListAsync();
        }
        public async Task AddProductToInventoryAsync(ProductDTO product) {
            var productNameParam = new SqlParameter("@productName", product.ProductName);

            await _db.Database
                .ExecuteSqlRawAsync("EXEC addProductToInv @productName", productNameParam);
        }
    }
}