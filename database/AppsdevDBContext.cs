using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.Extensions.Logging;

using GROCERYDISCOUNTBACKEND.MODELS;
using GROCERYDISCOUNTBACKEND.MODELS.VIEWS;
// Suggest: Use pooling to improve performance
namespace GROCERYDISCOUNTBACKEND.DATABASE {
    public class AppsdevDBContext: DbContext {
        private static readonly AppsdevDBContext _instance;
        public static AppsdevDBContext Instance => _instance;
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<InventoryModel> Inventories { get; set; }
        public DbSet<KioskModel> Kiosks { get; set; }
        public DbSet<RestockHistoryModel> RestockHistory { get; set; }
        public DbSet<SalesModel> Sales { get; set; }
        public DbSet<SalesDetailsModel> SalesDetails { get; set; }
        public DbSet<InventoryProductsViewModel> InventoryProducts { get; set; }
        public DbSet<PurchaseHistoryViewModel> PurchaseHistory { get; set; }
        public DbSet<RestockHistoryViewModel> RestockHistoryView { get; set; }
        static AppsdevDBContext() { _instance = new AppsdevDBContext(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            ConfigureDatabase(optionsBuilder);
        }
        // TODO: Check for errors
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryProductsViewModel>()
                .HasNoKey()
                .ToView("view_invProducts");

            modelBuilder.Entity<PurchaseHistoryViewModel>()
                .HasNoKey()
                .ToView("view_purchaseHistory");

            modelBuilder.Entity<RestockHistoryViewModel>()
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