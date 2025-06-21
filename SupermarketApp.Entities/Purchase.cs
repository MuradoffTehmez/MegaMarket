using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Təchizatçılardan edilən alış sifarişlərinin başlığını saxlayır.
    /// </summary>
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(100)]
        public string InvoiceNumber { get; set; } // Təchizatçının faktura nömrəsi

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public int UserId { get; set; } // Sifarişi edən işçi
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new HashSet<PurchaseDetail>();
    }
}