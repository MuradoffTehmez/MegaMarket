using Microsoft.EntityFrameworkCore;
using SupermarketApp.Entities;

namespace SupermarketApp.DataAccess
{
    /// <summary>
    /// Entity Framework Core üçün əsas verilənlər bazası konteksti sinifi.
    /// </summary>
    /// <remarks>
    /// Bu sinif proqramla verilənlər bazası arasında bir "körpü" rolunu oynayır.
    /// Bütün verilənlər bazası əməliyyatları (CRUD) bu sinif vasitəsilə həyata keçirilir.
    /// </remarks>
    public class MegaMarketDbContext : DbContext
    {
        // NOTE: Hər bir DbSet xassəsi verilənlər bazasındakı bir cədvələ uyğundur.
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Log> Logs { get; set; }

        /// <summary>
        /// Verilənlər bazası bağlantısını və provayderini konfiqurasiya edir.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // NOTE: Bu bağlantı sətri (connection string) yalnız lokal inkişaf (development) üçündür.
                // Miqrasiya fayllarının harada axtarılacağını da burada göstəririk.
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=MegaMarketDb;Trusted_Connection=True;TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("SupermarketApp.Migrations")
                );
            }
        }

        /// <summary>
        /// Varlıq modellərini və onların əlaqələrini Fluent API vasitəsilə daha detallı konfiqurasiya edir.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: Bu metod, Data Annotations ilə edilə bilməyən mürəkkəb ayarları tətbiq etmək üçündür.

            // --- Unikal Açar Təyinləmələri ---
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Barcode>().HasIndex(b => b.Code).IsUnique();

            // --- Əlaqə Konfiqurasiyaları ---

            // Product və Barcode arasında 1-ə-1 (One-to-One) əlaqə
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Barcode)
                .WithOne(b => b.Product)
                .HasForeignKey<Barcode>(b => b.ProductId);

            // Product və Promotion arasında Çoxdan-Çoxa (Many-to-Many) əlaqə
            modelBuilder.Entity<ProductPromotion>()
                .HasKey(pp => new { pp.ProductId, pp.PromotionId }); // Birləşik Primary Key

            // --- Silinmə Davranışlarının (Delete Behavior) Tənzimlənməsi ---

            // NOTE: Restrict ayarı, əlaqəli məlumatların təsadüfən silinməsinin qarşısını alır.
            modelBuilder.Entity<StockTransfer>().HasOne(st => st.FromWarehouse).WithMany().HasForeignKey(st => st.FromWarehouseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StockTransfer>().HasOne(st => st.ToWarehouse).WithMany().HasForeignKey(st => st.ToWarehouseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sale>().HasOne(s => s.User).WithMany().HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}