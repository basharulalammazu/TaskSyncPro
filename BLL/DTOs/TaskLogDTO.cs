using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class TaskLogDTO
    {
        public int Id { get; set; }

        public int TaskItemId { get; set; }

        public string Status { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}
