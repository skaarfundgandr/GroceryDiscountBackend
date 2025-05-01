using Microsoft.EntityFrameworkCore;

using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;
using GROCERYDISCOUNTBACKEND.MODELS;

namespace GROCERYDISCOUNTBACKEND.SERVICES {
    public class ProductService {
        private readonly AppsdevDBContext _db;
        public ProductService(AppsdevDBContext db) => _db = db;
        public async Task<List<ProductDTO>> GetProductsAsync() {
            return await _db.Products
                .Select(res => new ProductDTO {
                    ProductName = res.ProductName,
                    ProductDesc = res.ProductDesc,
                    ProductCategory = res.ProductCategory,
                    ProductPrice = res.ProductPrice
                })
                .ToListAsync();
        }
        public async Task AddProduct(Product prod) {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try {
                await _db.Products.AddAsync(prod);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Addition of product failed! Rolling back changes...");
            }
        }
    }
}