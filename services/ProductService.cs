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
        public async Task AddProductAsync(ProductDTO product) {
            using var transaction = await _db.Database.BeginTransactionAsync();
            
            try {
                Product prod = new Product {
                    ProductName = product.ProductName,
                    ProductCategory = product.ProductCategory,
                    ProductDesc = product.ProductDesc,
                    ProductPrice = product.ProductPrice
                };
                await _db.Products.AddAsync(prod);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Addition of product failed! Rolling back changes...");
            }
        }
        public async Task UpdateProductAsync(ProductDTO fromProduct, Product toProduct) {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try {
                long? prodId = await _db.Products
                    .Where(p => p.ProductName == fromProduct.ProductName)
                    .Select(p => (long?)p.ProductID)
                    .FirstOrDefaultAsync();
                if (prodId.HasValue) {
                    var updatedProduct = toProduct;
                    updatedProduct.ProductID = (long)prodId;
                    _db.Update(updatedProduct);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                } else {
                    await transaction.RollbackAsync();
                    throw new Exception("Product not found!");
                }
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Updating product failed! rolled back changes");
            }
        }
        public async Task RemoveProductAsync(ProductDTO prod) {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try {
                var product = await _db.Products
                    .FirstOrDefaultAsync(p => p.ProductName == prod.ProductName);
                
                if (product != null) {
                    _db.Remove(product);
                    
                    await _db.SaveChangesAsync();
                    await _db.Database.ExecuteSqlRawAsync("EXEC reseedAll");
                    await transaction.CommitAsync();
                } else {
                    await transaction.RollbackAsync();
                    throw new Exception("Product not found!");
                }
            } catch {
                await transaction.RollbackAsync();
                throw new Exception("Deletion of product failed! Rolled back changes.");
            }
        }
    }
}