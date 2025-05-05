using Microsoft.EntityFrameworkCore;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class InventoryService {
        private readonly AppsdevDBContext _db;

        public InventoryService(AppsdevDBContext db) => _db = db;

        public async Task<List<InventoryProductsViewDTO> GetInventoryProductsAsync() {
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
    }
}