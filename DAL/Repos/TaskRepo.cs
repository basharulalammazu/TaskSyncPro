using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TaskRepo : IRepository<EF.Models.Task>, ITaskFeature
    {
        private readonly TaskSyncDbContext db;
        public TaskRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        public bool Create(EF.Models.Task entity)
        {
            var existingRoles = GetTaskByTitle(entity.Title);
            if (existingRoles.Count > 0)
                throw new System.Exception("This title is already exists"); // Role with the same name already exists

            db.Tasks.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var dbRole = Find(id);
            if (dbRole == null)
                throw new System.Exception("This task is not found");

            db.Tasks.Remove(dbRole);
            return db.SaveChanges() > 0;
        }

        public EF.Models.Task Find(int id)
        {
            var role = db.Tasks.Find(id);
            if (role == null)
                throw new System.Exception("This role is not found");

            return role;
        }

        public List<EF.Models.Task> Find()
        {
            return db.Tasks.ToList();
        }

        public List<EF.Models.Task> GetTaskByTitle(string title)
        {
            return db.Tasks.Where(t => t.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public List<EF.Models.Task> GetTasksByPriority(string priority)
        {
            return db.Tasks
                     .Where(t => t.Priority != null &&
                                 t.Priority.ToLower().Contains(priority.ToLower()))
                     .ToList();
        }


        public List<EF.Models.Task> GetTasksWithEmployee(string employee)
        {
            return (from t in db.Tasks
                   where t.AssignedEmployee.User.Name.ToLower().Contains(employee.ToLower())
                   select t).ToList();


        }

        public EF.Models.Task GetTaskWithEmployee(int id)
        {
            return (from t in db.Tasks
                    where t.AssignedEmployee.Id == id
                    select t).SingleOrDefault();
        }

        public bool Update(EF.Models.Task entity)
        {
            var dbRole = Find(entity.Id);
            if (dbRole == null)
                throw new System.Exception("This task is not found");

            dbRole.Title = entity.Title;
            dbRole.Description = entity.Description;
            dbRole.Priority = entity.Priority;
            dbRole.Status = entity.Status;
            dbRole.AssignedEmployeeId = entity.AssignedEmployeeId;
            dbRole.DueDate = entity.DueDate;
            dbRole.CreatedAt = entity.CreatedAt;
            dbRole.CompletedAt = entity.CompletedAt;
            db.Entry(dbRole).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;

        }

        List<EF.Models.Task> ITaskFeature.GetTaskWithEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
