// See https://aka.ms/new-console-template for more information
using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.MODELS;
using GROCERYDISCOUNTBACKEND.SERVICES;

await using var db = new AppsdevDBContext();
var service = new ProductService(db);

Console.ReadKey();

await service.AddProductAsync(new Product{
    ProductName = "test",
    ProductCategory = "testing1",
    ProductPrice = 10.99m,
});

var results = await service.GetProductsAsync();

foreach (var s in results) {
    Console.WriteLine(s.ProductName + s.ProductDesc + s.ProductCategory + s.ProductPrice);
}