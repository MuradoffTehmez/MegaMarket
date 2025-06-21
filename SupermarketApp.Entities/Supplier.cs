using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Məhsulları təmin edən şirkət və ya fərdi təchizatçıların məlumatları.
    /// </summary>
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}