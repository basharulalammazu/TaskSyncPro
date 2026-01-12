using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskFeature
    {
        List<EF.Models.Task> GetTasksWithEmployee(string employee);
        EF.Models.Task GetTaskWithEmployee(int id);
        List<EF.Models.Task> GetTasksByPriority(string priority);
        EF.Models.Task GetTaskByTitle(string title);
    }
}
