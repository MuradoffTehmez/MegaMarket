using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Hər bir satış əməliyyatının başlığını (ümumi məlumatları) saxlayır.
    /// </summary>
    public class Sale
    {
        [Key]
        public int Id { get; set; } // Fiş nömrəsi

        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountAmount { get; set; }

        public int UserId { get; set; } // Satışı edən kassir
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int? CustomerId { get; set; } // Əgər qeydiyyatlı müştəridirsə
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();
    }
}