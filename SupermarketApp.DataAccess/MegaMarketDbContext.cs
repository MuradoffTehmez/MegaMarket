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
        /// <summary>
        /// DbContext-in konfiqurasiya seçimlərini qəbul edən əsas konstruktor.
        /// </summary>
        /// <param name="options">DbContext üçün konfiqurasiya seçimləri.</param>
        /// <remarks>
        /// Bu konstruktor, Dependency Injection və IDesignTimeDbContextFactory ilə işləmək üçün vacibdir.
        /// </remarks>
        public MegaMarketDbContext(DbContextOptions<MegaMarketDbContext> options) : base(options)
        {
        }

        // NOTE: OnConfiguring metodu məqsədli şəkildə silinmişdir.
        // Bütün konfiqurasiya (bağlantı sətri və s.) artıq xaricdən,
        // DbContextOptions vasitəsilə bu sinifə ötürülür.

        #region DbSets - Verilənlər Bazası Cədvəlləri

        /// <summary>
        /// İstifadəçilər cədvəli.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Rollar cədvəli.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Müştərilər cədvəli.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Məhsullar cədvəli.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Barkodlar cədvəli.
        /// </summary>
        public DbSet<Barcode> Barcodes { get; set; }

        /// <summary>
        /// Kateqoriyalar cədvəli.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Təchizatçılar cədvəli.
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Anbarlar/Filiallar cədvəli.
        /// </summary>
        public DbSet<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Anbar qalığı (stok) cədvəli.
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Anbarlar arası köçürmələr cədvəli.
        /// </summary>
        public DbSet<StockTransfer> StockTransfers { get; set; }

        /// <summary>
        /// Satışlar cədvəli.
        /// </summary>
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// Satış detalları cədvəli.
        /// </summary>
        public DbSet<SaleDetail> SaleDetails { get; set; }

        /// <summary>
        /// Alışlar cədvəli.
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        /// Alış detalları cədvəli.
        /// </summary>
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        /// <summary>
        /// Kampaniyalar cədvəli.
        /// </summary>
        public DbSet<Promotion> Promotions { get; set; }

        /// <summary>
        /// Məhsul-Kampaniya əlaqə cədvəli.
        /// </summary>
        public DbSet<ProductPromotion> ProductPromotions { get; set; }

        /// <summary>
        /// Ödəniş metodları cədvəli.
        /// </summary>
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        /// <summary>
        /// Sistem logları cədvəli.
        /// </summary>
        public DbSet<Log> Logs { get; set; }

        #endregion

        /// <summary>
        /// Varlıq modellərini və onların əlaqələrini Fluent API vasitəsilə daha detallı konfiqurasiya edir.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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