using SupermarketApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketApp.Core.Interfaces
{
    /// <summary>
    /// Product varlığı üçün spesifik data əməliyyatlarını təyin edir.
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product>
    {
        // NOTE: Bu interfeys IGenericRepository-dən bütün ümumi metodları miras alır. Bura yalnız Product-a məxsus olan metodlar əlavə ediləcək.

        /// <summary>
        /// Verilmiş kateqoriya ID-sinə aid olan bütün məhsulları gətirir.
        /// </summary>
        /// <param name="categoryId">Kateqoriya ID-si.</param>
        /// <returns>Həmin kateqoriyadakı məhsulların siyahısı.</returns>
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);

        // TODO: Gələcəkdə "Ən çox satılan məhsullar" və ya "Stoku kritik səviyyədə olan məhsullar" kimi xüsusi metodlar bura əlavə edilə bilər.
    }
}