using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TeamRepo : IRepository<Team>, ITeamFeature
    {
        private readonly TaskSyncDbContext db;
        public TeamRepo(TaskSyncDbContext db) 
        { 
            this.db = db; 
        }

        public bool Create(Team t) 
        { 
            if (db.Teams.Any(existing => existing.Name == t.Name)) 
                throw new Exception("Team with the same name already exists.");

            db.Teams.Add(t); 
            return db.SaveChanges() > 0; 
        }
        

        public List<Team> Find() 
        { 
            return db.Teams.ToList(); 
        }

        public Team Find(int id)
        {
            return db.Teams.Find(id);
        }

        public List<Team> Find(string name)
        {
            return db.Teams.Where(t => t.Name.Contains(name)).ToList();
        }


        public bool Update(Team t) 
        { 
            var ex = Find(t.Id); 
            db.Entry(ex).CurrentValues.SetValues(t); 
            return db.SaveChanges() > 0; 
        }

        public bool Delete(int id)
        {
            var ex = Find(id);
            if (ex == null)
                return false;

            db.Teams.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Team> GetTeamsWithEmployees()
        {
            return db.Teams.Include(t => t.Employees).ToList();
        }

        public Team GetTeamWithEmployee(int id)
        {
            return db.Teams.Include(t => t.Employees).FirstOrDefault(t => t.Id == id);
        }

        public Employee GetEmployeeWithDetails(int id)
        {
            return db.Employees
                .Include(e => e.User)
                .Include(e => e.Team)
                .Include(e => e.Tasks)
                .FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployeeWithDetails()
        {
            return db.Employees
                .Include(e => e.User)
                .Include(e => e.Team)
                .Include(e => e.Tasks)
                .ToList();
        }

    }
}
