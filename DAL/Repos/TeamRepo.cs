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
            db.Teams.Add(t); 
            return db.SaveChanges() > 0; 
        }

        public bool Delete(int id) 
        { 
            var ex = Find(id); 
            db.Teams.Remove(ex); 
            return db.SaveChanges() > 0; 
        }

        public Team Find(int id) 
        { 
            return db.Teams.Find(id); 
        }

        public List<Team> Find() 
        { 
            return db.Teams.ToList(); 
        }

        public bool Update(Team t) 
        { 
            var ex = Find(t.Id); 
            db.Entry(ex).CurrentValues.SetValues(t); 
            return db.SaveChanges() > 0; 
        }

        public List<Team> GetTeamsWithEmployees()
        {
            return db.Teams.Include(t => t.Employees).ToList();
        }

        public Team GetTeamWithEmployees(int id)
        {
            return db.Teams.Include(t => t.Employees).FirstOrDefault(t => t.Id == id);
        }
    }
}
