using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Hər bir məhsul üçün unikal barkodu saxlayır. Product ilə 1-ə-1 əlaqəlidir.
    /// </summary>
    public class Barcode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; } // EAN-13, UPC, və ya digər standartlar

        // Foreign Key to Product
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}