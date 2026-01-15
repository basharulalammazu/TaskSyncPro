using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class TeamRepo : ITeamFeature
    {
        private readonly TaskSyncDbContext db;
        public TeamRepo(TaskSyncDbContext db) 
        { 
            this.db = db; 
        }

        public List<Team> Find(string name)
        {
            return db.Teams.Where(t => t.Name.Contains(name)).ToList();
        }

        public bool Find(int id, string name)
        {
            return db.Teams.Any(t => t.Name == name && t.Id != id);
        }

        public Team SearchByName(string name)
        {
            return db.Teams.FirstOrDefault(t => t.Name == name);
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
            return db.Employees.Include(e => e.User).Include(e => e.Team).Include(e => e.Tasks).FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployeeWithDetails()
        {
            return db.Employees.Include(e => e.User).Include(e => e.Team).Include(e => e.Tasks).ToList();
        }

    }
}
