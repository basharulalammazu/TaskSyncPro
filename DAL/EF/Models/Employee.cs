using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Designation { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
