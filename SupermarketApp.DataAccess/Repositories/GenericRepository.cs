using Microsoft.EntityFrameworkCore;
using SupermarketApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupermarketApp.DataAccess.Repositories
{
    /// <summary>
    /// IGenericRepository interfeysini həyata keçirən və EF Core istifadə edərək ümumi data əməliyyatlarını yerinə yetirən sinif.
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // NOTE: Bu sinif birbaşa DbContext ilə işləyir. Protected olması,
        // törəmə siniflərin (məs: ProductRepository) də ona çıxışını təmin edir.
        protected readonly MegaMarketDbContext _context;

        public GenericRepository(MegaMarketDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            // NOTE: Update və Delete metodları asinxron deyil, çünki onlar sadəcə
            // varlığın vəziyyətini (state) dəyişir. Faktiki əməliyyat SaveChanges zamanı baş verir.
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}