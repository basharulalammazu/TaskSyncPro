using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskFeature 
    {
        List<EF.Models.Task> GetTasksByPriority(string priority);
        List<EF.Models.Task> GetTasksByStatus(string priority);
        List<EF.Models.Task> GetTaskByTitle(string title);
        public EF.Models.Task SearchTaskByTitle(string title);
        public bool TitleExistsForOtherTask(string title, int id);
        public bool ExistsForEmployee(string title, int? employeeId);
        public bool ExistsForEmployeeExcludingTask(string title, int? employeeId, int taskId);

    }
}
