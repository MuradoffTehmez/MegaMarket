using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Entities
{
    /// <summary>
    /// İstifadəçilərin sistemdəki səlahiyyətlərini müəyyən edən rolları saxlayır.
    /// </summary>
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // Məs: Super Admin, Kassir, Anbar Meneceri

        [StringLength(500)]
        public string Description { get; set; }

        // NOTE: İcazələr (permissions) JSON formatında saxlanılaraq daha çevik idarəetmə təmin edilə bilər.
        public string Permissions { get; set; }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}