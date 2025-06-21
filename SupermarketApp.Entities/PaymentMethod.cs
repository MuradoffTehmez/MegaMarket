using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Mümkün ödəniş metodlarını saxlayan köməkçi cədvəl. (Nağd, Kart və s.)
    /// </summary>
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}