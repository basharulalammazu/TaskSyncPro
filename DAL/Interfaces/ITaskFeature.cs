using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskFeature : IRepository<EF.Models.Task>
    {
        List<EF.Models.Task> GetTasksByPriority(string priority);
        List<EF.Models.Task> GetTaskByTitle(string title);
    }
}
