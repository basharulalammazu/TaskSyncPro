using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TeamPerformanceDTO
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int OverdueTasks { get; set; }

        public double AvgCompletionTimeDays { get; set; }
        public double PerformanceScore { get; set; }
        public string Grade { get; set; }
    }
}
