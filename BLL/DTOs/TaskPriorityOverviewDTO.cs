using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TaskPriorityOverviewDTO
    {
        public int TotalTasks { get; set; }
        public int LowPriorityTasks { get; set; }
        public int MediumPriorityTasks { get; set; }
        public int HighPriorityTasks { get; set; }
    }
}
