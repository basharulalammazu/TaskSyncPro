using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TaskLogRepo : ITaskLogFeature
    {
        private readonly TaskSyncDbContext db;
        public TaskLogRepo(TaskSyncDbContext db) 
        { 
            this.db = db; 
        }

        public bool Create(TaskLog log) 
        { 
            db.TaskLogs.Add(log); 
            return db.SaveChanges() > 0; 
        }

        public bool Delete(int id) 
        {
            var ex = Find(id);
            if (ex == null) 
                return false; 

            db.TaskLogs.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public TaskLog Find(int id) 
        { 
            return db.TaskLogs.Find(id); 
        }

        public List<TaskLog> Find() 
        { 
            return db.TaskLogs.ToList(); 
        }
        
        public bool Update(TaskLog log) 
        {
            var ex = Find(log.Id);
            if (ex == null) 
                return false;
            
            db.Entry(ex).CurrentValues.SetValues(log);
            return db.SaveChanges() > 0;

        }

        public bool TaskLogExists(int id, int taskId)
        {
            return db.TaskLogs.Any(l => l.Id != id && l.TaskItemId == taskId);
        }

        public List<TaskLog> GetTaskLogsByTaskId(int taskId)
        {
            return db.TaskLogs.Where(l => l.TaskItemId == taskId).ToList();
        }
    }
}
