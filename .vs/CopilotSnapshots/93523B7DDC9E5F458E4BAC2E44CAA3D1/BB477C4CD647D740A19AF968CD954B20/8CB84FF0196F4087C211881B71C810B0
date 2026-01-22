using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class ReportRepo : IReports
    {
        private readonly TaskSyncDbContext db;

        public ReportRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        public List<EF.Models.Task> GetTasks(DateTime from, DateTime to)
        {
            return db.Tasks
                .Where(t => t.CreatedAt >= from && t.CreatedAt <= to)
                .ToList();
        }


        public List<EF.Models.Task> GetTasksCompleted(DateTime from, DateTime to)
        {
            return db.Tasks
                .Where(t => t.CompletedAt >= from && t.CompletedAt <= to)
                .ToList();
        }

        public List<Employee> GetEmployeesWithTasks(DateTime from, DateTime to)
        {
            return db.Employees
                .Include(e => e.User)
                .Include(e => e.Tasks.Where(t =>
                    t.CreatedAt >= from && t.CreatedAt <= to))
                .ToList();
        }

        public List<Team> GetTeamsWithTasks(DateTime from, DateTime to)
        {
            return db.Teams
                .Include(t => t.Employees)
                .ThenInclude(e => e.Tasks.Where(ts => ts.CreatedAt >= from && ts.CreatedAt <= to))
                .ToList();
        }

    }
}
