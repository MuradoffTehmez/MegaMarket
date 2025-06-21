using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Product və Promotion arasında Çoxdan-Çoxa əlaqəni quran aralıq cədvəl.
    /// </summary>
    public class ProductPromotion
    {
        // Foreign Keys that form a composite Primary Key
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int PromotionId { get; set; }
        [ForeignKey("PromotionId")]
        public virtual Promotion Promotion { get; set; }
    }
}