using SupermarketApp.Core.Interfaces;
using SupermarketApp.DataAccess.Repositories;
using System.Threading.Tasks;
using SupermarketApp.DataAccess;

namespace SupermarketApp.DataAccess
{
    /// <summary>
    /// IUnitOfWork interfeysini həyata keçirir.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MegaMarketDbContext _context;

        // NOTE: Hər bir repository üçün private bir xassə və public bir interfeys təyin edilir.
        // Bu, repository-lərin "lazy loading" prinsipi ilə, yəni yalnız lazım olduqda
        // yaradılmasını təmin edə bilər, lakin sadəlik üçün birbaşa yaradırıq.
        public IProductRepository Products { get; private set; }
        // TODO: Digər repository-lər üçün də eyni şəkildə xassələr yaradılacaq.
        // public ISaleRepository Sales { get; private set; }

        public UnitOfWork(MegaMarketDbContext context)
        {
            _context = context;

            // Bütün repository-lərin instansiyaları burada yaradılır
            Products = new ProductRepository(_context);
            // Sales = new SaleRepository(_context);
        }

        /// <summary>
        /// Bütün dəyişiklikləri verilənlər bazasına yazır.
        /// </summary>
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// DbContext tərəfindən istifadə olunan resursları azad edir.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}