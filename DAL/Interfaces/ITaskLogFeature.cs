using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskLogFeature : IRepository<TaskLog>
    {
        List<TaskLog> GetTaskLogsByTaskId(int taskId);
    }
}
