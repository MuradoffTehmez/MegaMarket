using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Anbarlar arasında edilən məhsul köçürmələrini qeyd edir.
    /// </summary>
    public class StockTransfer
    {
        [Key]
        public int Id { get; set; }

        public DateTime TransferDate { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public int FromWarehouseId { get; set; }
        public virtual Warehouse FromWarehouse { get; set; }

        public int ToWarehouseId { get; set; }
        public virtual Warehouse ToWarehouse { get; set; }

        public int UserId { get; set; } // Transferi edən işçi
        public virtual User User { get; set; }
    }
}