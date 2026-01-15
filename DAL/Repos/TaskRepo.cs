using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TaskRepo : ITaskFeature
    {
        private readonly TaskSyncDbContext db;
        public TaskRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        
        public List<EF.Models.Task> GetTaskByTitle(string title)
        {
            return db.Tasks.Where(t => t.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public EF.Models.Task SearchTaskByTitle(string title)
        {
            return db.Tasks.Where(t => t.Title.ToLower() == title.ToLower()).FirstOrDefault();
        }



        public bool TitleExistsForOtherTask(string title, int id)
        {
            return db.Tasks.Any(t => t.Title.ToLower() == title.ToLower() && t.Id != id);

        }

        public bool ExistsForEmployeeExcludingTask(string title, int? employeeId, int taskId)
        {
            if (employeeId == null)
                return false;

            return db.Tasks.Any(t =>t.AssignedEmployeeId == employeeId && t.Title == title && t.Id != taskId);
        }

        public List<EF.Models.Task> GetTasksByPriority(string priority)
        {
            return db.Tasks
                     .Where(t => t.Priority != null &&
                                 t.Priority.ToLower().Contains(priority.ToLower()))
                     .ToList();
        }

        public bool ExistsForEmployee(string title, int? employeeId)
        {
            return db.Tasks.Any(t =>t.AssignedEmployeeId == employeeId && t.Title == title);
        }
    }
}
