using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class BillingRecord
    {
        public int Id { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public decimal Amount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaidAt { get; set; }

        // Navigation
        public virtual Task Task { get; set; }
    }
}
