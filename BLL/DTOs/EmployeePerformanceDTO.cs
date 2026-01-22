using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class EmployeePerformanceDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int AssignedTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int OverdueTasks { get; set; }

        public double AvgCompletionTimeDays { get; set; }
        public double EfficiencyScore { get; set; }
        public string Grade { get; set; }
    }
}
