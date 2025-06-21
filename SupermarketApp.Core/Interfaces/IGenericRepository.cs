using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupermarketApp.Core.Interfaces
{
    /// <summary>
    /// Bütün varlıqlar üçün ümumi data əməliyyatlarını təyin edən generic repository interfeysi.
    /// </summary>
    /// <typeparam name="T">Varlıq sinifi (məs: Product, Category).</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Verilmiş ID-yə əsasən varlığı tapır.
        /// </summary>
        /// <param name="id">Axtarılan varlığın ID-si.</param>
        /// <returns>Tapılmış varlıq və ya null.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Cədvəldəki bütün qeydləri gətirir.
        /// </summary>
        /// <returns>Varlıqların siyahısı.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Verilmiş şərtə uyğun qeydləri tapır.
        /// </summary>
        /// <param name="expression">Axtarış üçün lambda ifadəsi (məs: x => x.IsActive).</param>
        /// <returns>Şərtə uyğun varlıqların siyahısı.</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Yeni bir varlığı verilənlər bazasına əlavə edir.
        /// </summary>
        /// <param name="entity">Əlavə ediləcək varlıq.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Birdən çox varlığı verilənlər bazasına əlavə edir.
        /// </summary>
        /// <param name="entities">Əlavə ediləcək varlıqların siyahısı.</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Mövcud varlığı yeniləyir.
        /// </summary>
        /// <param name="entity">Yenilənəcək varlıq.</param>
        void Update(T entity);

        /// <summary>
        /// Verilmiş varlığı verilənlər bazasından silir.
        /// </summary>
        /// <param name="entity">Silinəcək varlıq.</param>
        void Delete(T entity);

        /// <summary>
        /// Birdən çox varlığı verilənlər bazasından silir.
        /// </summary>
        /// <param name="entities">Silinəcək varlıqların siyahısı.</param>
        void DeleteRange(IEnumerable<T> entities);
    }
}