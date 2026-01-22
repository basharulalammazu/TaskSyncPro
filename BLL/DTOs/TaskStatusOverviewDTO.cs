using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TaskStatusOverviewDTO
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int InProgress { get; set; }
        public int PendingTasks { get; set; }
        public int OverdueTasks { get; set; }
    }
}
