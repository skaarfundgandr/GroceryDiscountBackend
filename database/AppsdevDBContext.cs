using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.Extensions.Logging;

using GROCERYDISCOUNTBACKEND.MODELS;
using GROCERYDISCOUNTBACKEND.MODELS.VIEWS;
// Suggest: Use pooling to improve performance 
namespace GROCERYDISCOUNTBACKEND.DATABASE {
    public class AppsdevDBContext: DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<RestockHistory> RestockHistory { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<InventoryProductsView> InventoryProducts { get; set; }
        public DbSet<PurchaseHistoryView> PurchaseHistory { get; set; }
        public DbSet<RestockHistoryView> RestockHistoryView { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            ConfigureDatabase(optionsBuilder);
        }
        // TODO: Check for errors
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryProductsView>()
                .HasNoKey()
                .ToView("view_invProducts");
            
            modelBuilder.Entity<PurchaseHistoryView>()
                .HasNoKey()
                .ToView("view_purchaseHistory");

            modelBuilder.Entity<RestockHistoryView>()
                .HasNoKey()
                .ToView("view_restockHistory");
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