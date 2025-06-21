using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Marketin qeydiyyatlı və sadiq müştərilərinin məlumatlarını saxlayır.
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // TODO: Gələcəkdə "Loyalty" (sadiqlik) proqramı ilə inteqrasiya üçün bonus balansı xassəsi əlavə edilə bilər.
        // public decimal BonusBalance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}