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

        public IUserFeature UserDataAccess()
        {
            return new UserRepo(db);
        }

        public IRole RoleDataAccess()
        {
            return new RoleRepo(db);
        }

        public ITaskFeature TaskDataAccess()
        {
            return new TaskRepo(db);
        }
    }
}
