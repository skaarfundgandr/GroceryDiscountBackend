// See https://aka.ms/new-console-template for more information
using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.SERVICES;

await using var db = AppsdevDBContext.Instance;
var service = new ProductService(db);

Console.ReadKey();

var results = await service.GetProductsAsync();
foreach (var s in results) {
    Console.WriteLine(s.ProductName + s.ProductDesc + s.ProductCategory + s.ProductPrice);
}