// See https://aka.ms/new-console-template for more information
using GROCERYDISCOUNTBACKEND.DATABASE;
using GROCERYDISCOUNTBACKEND.SERVICES;

await using var db = new AppsdevDBContext();
var results = await new ProductService(db).GetProductsAsync();

foreach (var s in results) {
    Console.WriteLine(s.ProductName + s.ProductDesc + s.ProductCategory + s.ProductPrice);
}