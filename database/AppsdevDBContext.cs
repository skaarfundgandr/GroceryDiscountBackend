using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.Extensions.Logging;

using GROCERYDISCOUNTBACKEND.MODELS;
using GROCERYDISCOUNTBACKEND.MODELS.VIEWS;

namespace GROCERYDISCOUNTBACKEND.DATABASE {
    public class AppsdevDBContext: DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<RestockHistory> RestockHistories { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<InventoryProductsView> InventoryProducts { get; set; }
        public DbSet<PurchaseHistoryView> PurchaseHistory { get; set; }
        public DbSet<RestockHistoryView> RestockHistory { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            ConfigureDatabase(optionsBuilder);
        }
        private void ConfigureDatabase(DbContextOptionsBuilder options) {
            Env.Load();
            String connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                            throw new Exception("Connection string is empty! Did you set an environment variable?");

            options
                .UseSqlServer(connStr)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}