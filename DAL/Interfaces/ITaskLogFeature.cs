using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITaskLogFeature
    {
        public bool TaskLogExists(int id, int taskId);
        List<TaskLog> GetTaskLogsByTaskId(int taskId);
    }
}
