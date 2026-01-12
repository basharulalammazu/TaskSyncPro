using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class TaskSyncDbContext : DbContext
    {
        public TaskSyncDbContext(DbContextOptions<TaskSyncDbContext> options)
            : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<TaskLog> TaskLogs { get; set; }
        public DbSet<BillingRecord> BillingRecords { get; set; }

    }
}
