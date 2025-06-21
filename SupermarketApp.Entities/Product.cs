using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Satış üçün nəzərdə tutulan bütün məhsulların məlumatlarını saxlayan əsas varlıq.
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }

        public int StockQuantity { get; set; }

        public int CriticalStockLevel { get; set; }

        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual Barcode Barcode { get; set; }

        public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new HashSet<ProductPromotion>();
    }
}