using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class RoleRepo : IRole
    {
        private readonly TaskSyncDbContext db;
        public RoleRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }


        public Role Find(int id)
        {
            return db.Roles.Find(id);
        }



        public List<Role> Find(string role)
        {
            var data = (from r in db.Roles
                          where r.Name.ToLower().Contains(role.ToLower())
                          select r).ToList();

            return data;
        }


    }
}
