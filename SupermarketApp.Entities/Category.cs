using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Məhsulları qruplaşdırmaq üçün istifadə olunan kateqoriyaları təmsil edir.
    /// </summary>
    /// <remarks>
    /// Çoxsəviyyəli (parent-child) kateqoriya quruluşunu dəstəkləyir.
    /// </remarks>
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Self-referencing Foreign Key for parent category
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}