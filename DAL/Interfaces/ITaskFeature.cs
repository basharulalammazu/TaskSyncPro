using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskFeature : IRepository<EF.Models.Task>
    {
        List<EF.Models.Task> GetTasksWithEmployee(string employee);
        List<EF.Models.Task> GetTaskWithEmployee(int id);
        List<EF.Models.Task> GetTasksByPriority(string priority);
        List<EF.Models.Task> GetTaskByTitle(string title);
    }
}
