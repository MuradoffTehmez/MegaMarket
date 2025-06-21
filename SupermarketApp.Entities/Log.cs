using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// Sistemdə baş verən vacib əməliyyatların və xətaların qeydini saxlayır (Audit Log).
    /// </summary>
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Level { get; set; } // INFO, WARNING, ERROR, CRITICAL

        [Required]
        public string Message { get; set; }

        public string Exception { get; set; }

        public int? UserId { get; set; } // Əməliyyatı edən istifadəçi (əgər varsa)
        public virtual User User { get; set; }
    }
}