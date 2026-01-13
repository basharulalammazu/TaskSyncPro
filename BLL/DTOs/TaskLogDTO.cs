using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TaskLogDTO
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
