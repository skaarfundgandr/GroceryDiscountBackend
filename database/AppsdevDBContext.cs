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
        public DbSet<RestockHistory> RestockHistories { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<InventoryProductsView> InventoryProducts { get; set; }
        public DbSet<PurchaseHistoryView> PurchaseHistory { get; set; }
        public DbSet<RestockHistoryView> RestockHistory { get; set; } 
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

            modelBuilder.Entity<Inventory>(inv => {
                inv.HasKey(i => i.InventoryID);

                inv.Property(i => i.Units)
                    .HasMaxLength(50);
                
                inv.Property(i => i.Quantity)
                    .IsRequired();
                
                inv.Property(i => i.LatestRestock);

                inv.HasOne(i => i.Product)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(p => p.ProductID);
                
                inv.HasMany(i => i.RestockHistory)
                    .WithOne(rh => rh.Inventory)
                    .HasForeignKey(rh => rh.InventoryID);
                
                inv.HasMany(i => i.Sales)
                    .WithMany(s => s.Inventory)
                    .UsingEntity(t => t.ToTable("salesDetails"));
            });

            modelBuilder.Entity<Kiosk>(kiosk => {
                kiosk.HasKey(k => k.KioskID);

                kiosk.Property(k => k.Username)
                    .HasMaxLength(50)
                    .IsRequired();
                
                kiosk.Property(k => k.Password)
                    .HasMaxLength(50)
                    .IsRequired();

                kiosk.HasMany(k => k.Sales)
                    .WithMany(s => s.Kiosk)
                    .UsingEntity(t => t.ToTable("salesDetails"));
                
                kiosk.HasMany(k => k.Inventory)
                    .WithMany(i => i.Kiosk)
                    .UsingEntity(t => t.ToTable("salesDetails"));
            });

            modelBuilder.Entity<Sales> (sales => {
                sales.HasKey(s => s.SalesID);

                sales.Property(s => s.Amount)
                    .IsRequired();
                
                sales.Property(s => s.Date)
                    .IsRequired();

                sales.HasMany(s => s.Kiosk)
                    .WithMany(k => k.Sales)
                    .UsingEntity(t => t.ToTable("salesDetails"));
                
                sales.HasMany(s => s.Inventory)
                    .WithMany(i => i.Sales)
                    .UsingEntity(t => t.ToTable("salesDetails"));
            });
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