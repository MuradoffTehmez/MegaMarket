using System;
using System.Threading.Tasks;

namespace SupermarketApp.Core.Interfaces
{
    /// <summary>
    /// Bütün repository-ləri bir araya gətirən və data əməliyyatlarını tək bir tranzaksiya kimi idarə edən Unit of Work interfeysi.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Məhsul repository-sinə çıxışı təmin edir.
        /// </summary>
        IProductRepository Products { get; }

        // TODO: Digər bütün repository interfeysləri (ISaleRepository, IUserRepository və s.)
        // bura xassə (property) kimi əlavə ediləcək.
        // Məsələn:
        // ISaleRepository Sales { get; }
        // IUserRepository Users { get; }

        /// <summary>
        /// Edilmiş bütün dəyişiklikləri vahid bir əməliyyat kimi verilənlər bazasına yazır.
        /// </summary>
        /// <returns>Dəyişikliyin uğurlu olub-olmadığını göstərən tam ədəd.</returns>
        Task<int> CompleteAsync();
    }
}