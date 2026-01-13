using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Repos
{
    internal class EmployeeRepo : IRepository<Employee>, IEmployeeFeature
    {
        private readonly TaskSyncDbContext db;
        public EmployeeRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        public bool Create(Employee entity)
        {
            if (db.Employees.Any(e => e.UserId == entity.UserId))
                throw new InvalidOperationException("Employee with the same user already exists.");

            if (db.Employees.Any(e => e.TeamId == entity.TeamId && e.Designation == entity.Designation))
                throw new InvalidOperationException("Employee with the same team and designation already exists.");

            if (!db.Users.Any(u => u.Id == entity.UserId))
                throw new InvalidOperationException("User with the specified UserId does not exist.");

            if (!db.Teams.Any(t => t.Id == entity.TeamId))
                throw new InvalidOperationException("Team with the specified TeamId does not exist.");

            db.Employees.Add(entity);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var emp = Find(id);
            if (emp == null) 
                return false;

            db.Employees.Remove(emp);
            return db.SaveChanges() > 0;
        }


        public Employee Find(int id)
        {
            var role = db.Employees.Find(id);
            if (role == null)
                return null;

            return role;
        }

        public List<Employee> Find()
        {
            return db.Employees.ToList();
        }

        public Employee FindByUserEmail(string email)
        {
            var data = (from e in db.Employees
                       where e.User.Email == email
                       select e).SingleOrDefault();
            if (data == null)
                return null;

            return data;
        }

        public List<Employee> GetEmployeesWithTasks()
        {
            var employees = (from e in db.Employees.Include(e => e.Tasks).ThenInclude(t => t.AssignedEmployee)
                                select e
                            ).ToList();

            if (employees == null)
                return null;

            return employees;

        }

        public Employee GetEmployeeWithTasks(int id)
        {
            var employee = ( from e in db.Employees
                                             .Include(e => e.Tasks)
                                             .ThenInclude(t => t.AssignedEmployee)
                                where e.Id == id
                                select e
                            ).FirstOrDefault();

            if (employee == null)
                return null;

            return employee;

        }

        public bool Update(Employee entity)
        {
            var dbRole = Find(entity.Id);
            if (dbRole == null)
                return false;

            db.Entry(dbRole).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;

        }
    }
}
