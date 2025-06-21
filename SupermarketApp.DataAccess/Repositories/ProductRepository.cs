using Microsoft.EntityFrameworkCore;
using SupermarketApp.Core.Interfaces;
using SupermarketApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketApp.DataAccess.Repositories
{
    /// <summary>
    /// IProductRepository interfeysini həyata keçirir.
    /// </summary>
    /// <remarks>
    /// GenericRepository-dən miras aldığı üçün bütün ümumi CRUD əməliyyatlarına sahibdir.
    /// </remarks>
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MegaMarketDbContext context) : base(context)
        {
            // NOTE: base(context) əmri, ana sinif olan GenericRepository-nin konstruktoruna
            // DbContext obyektini ötürür.
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                                 .Where(p => p.CategoryId == categoryId)
                                 .ToListAsync();
        }
    }
}