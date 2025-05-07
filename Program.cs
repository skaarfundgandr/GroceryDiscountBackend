// See https://aka.ms/new-console-template for more information
using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.DTO;
using GROCERYDISCOUNTBACKEND.SERVICES;

await using var db = AppsdevDBContext.Instance;
var service = new ProductService();

Console.ReadKey();
ProductDTO Product = new ProductDTO {
    ProductName = "Test",
    ProductCategory = "Testcat",
    ProductPrice = 99.99m,
    ProductDesc = "Testdesc"
};
await service.AddProductAsync(Product);
var results = await service.GetProductsAsync();
foreach (var s in results) {
    Console.WriteLine(s.ProductName + s.ProductDesc + s.ProductCategory + s.ProductPrice);
}