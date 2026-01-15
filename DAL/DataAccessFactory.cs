using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        TaskSyncDbContext db;

        public DataAccessFactory(TaskSyncDbContext db)
        {
            this.db = db;
        }

        // Generic repository access
        public IRepository<T> GetRepo<T>() where T : class
        {
            return new Repository<T>(db);
        }

        // Feature-specific repositories
        public IBillingFeature BillingDataAccess()
        {
            return new BillingRecordRepo(db);
        }

        public IEmployeeFeature EmployeeDataAccess()
        {
            return new EmployeeRepo(db);
        }

        public IRole RoleDataAccess()
        {
            return new RoleRepo(db);
        }


        public ITaskFeature TaskDataAccess()
        {
            return new TaskRepo(db);
        }

        public ITaskLogFeature TaskLogDataAccess()
        {
            return new TaskLogRepo(db);
        }

        public ITeamFeature TeamDataAccess()
        {
            return new TeamRepo(db);
        }


        public IUserFeature UserDataAccess()
        {
            return new UserRepo(db);
        }
    }
}
