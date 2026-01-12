using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace DAL.EF.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        [Column(TypeName = "VARCHAR")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public virtual Role Role { get; set; }
    }
}
