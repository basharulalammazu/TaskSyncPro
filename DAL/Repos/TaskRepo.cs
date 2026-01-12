using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TaskRepo // :   IRepository<TaskItem>, ITaskFeature
    {
        /*
        public bool Create(TaskItem entity)
        {
            var taskCheck  = db.TaskItems.FirstOrDefault(t => t.Title.ToLower() == entity.Title.ToLower());

            if (taskCheck != null)
                throw new Exception("A task with the same title already exists.");

            db.TaskItems.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var dbTask = db.TaskItems.Find(id);
            if (dbTask == null)
                return false;
            db.TaskItems.Remove(dbTask);
            return db.SaveChanges() > 0;
        }

        public TaskItem Find(int id)
        {
            return db.TaskItems.Find(id);
        }

        public List<TaskItem> Find()
        {
            return db.TaskItems.ToList();
        }

        public TaskItem GetTaskByTitle(string title)
        {
            return db.TaskItems.FirstOrDefault(t => t.Title.ToLower().Contains(title.ToLower()));
        }

        public List<TaskItem> GetTasksByPriority(string priority)
        {
            return db.TaskItems.Where(t => t.Priority.ToLower() == priority).ToList();
        }

        public List<TaskItem> GetTasksWithEmployee(string employee)
        {
            var tasks = from task in db.TaskItem
                        where task.User.Name.tolower() == contain(employeeName)
                        select task).toList();
        }

        public TaskItem GetTaskWithEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskItem entity)
        {
            throw new NotImplementedException();
        }
        */
    }
}
