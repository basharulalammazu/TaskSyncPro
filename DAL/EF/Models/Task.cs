using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Priority { get; set; } // Low, Medium, High

        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Status { get; set; }   // Pending, InProgress, Completed, Overdue

        [ForeignKey("AssignedEmployee")]
        public int? AssignedEmployeeId { get; set; }

        [ForeignKey("Creator")]
        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation
        public virtual Employee AssignedEmployee { get; set; }
        public virtual User Creator { get; set; }

        public virtual BillingRecord BillingRecord { get; set; }
    }
}
