using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Məhsulların saxlandığı fiziki anbarları və ya filialları təmsil edir.
    /// </summary>
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Məs: "Mərkəz Anbar", "Gəncə Filialı"

        [StringLength(250)]
        public string Location { get; set; }
    }
}