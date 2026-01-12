using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class TaskLog
    {
        public int Id { get; set; }

        [ForeignKey("TaskItem")]
        public int TaskItemId { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Status { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.Now;

        // Navigation
        public virtual Task TaskItem { get; set; }
    }
}
