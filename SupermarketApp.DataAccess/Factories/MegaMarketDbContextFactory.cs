using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SupermarketApp.DataAccess.Factories
{
    /// <summary>
    /// EF Core-un dizayn zamanı (məs: Add-Migration) alətləri üçün DbContext yaratmaq məqsədilə istifadə etdiyi fabrik sinifi.
    /// </summary>
    public class MegaMarketDbContextFactory : IDesignTimeDbContextFactory<MegaMarketDbContext>
    {
        public MegaMarketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MegaMarketDbContext>();

            // NOTE: Bağlantı sətri və miqrasiya assembly-si burada, xüsusi olaraq
            // dizayn zamanı alətləri üçün yenidən təyin edilir.
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=MegaMarketDb;Trusted_Connection=True;TrustServerCertificate=True;",
                b => b.MigrationsAssembly("SupermarketApp.Migrations")
            );

            return new MegaMarketDbContext(optionsBuilder.Options);
        }
    }
}