using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Müəyyən bir məhsulun müəyyən bir anbarda olan miqdarını saxlayır.
    /// </summary>
    // NOTE: Bu cədvəl tranzaksional olaraq yenilənməlidir. Hər alış/satışda dəyişir.
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
    }
}