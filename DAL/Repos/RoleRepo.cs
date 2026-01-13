using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class RoleRepo : IRepository<DAL.EF.Models.Role>, IRole
    {
        private readonly TaskSyncDbContext db;
        public RoleRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        public bool Create(Role entity)
        {
            var existingRoles = Find(entity.Name);
            if (existingRoles.Count > 0)
                return false;

            db.Roles.Add(entity);
            return db.SaveChanges() > 0;

        }

        public bool Delete(int id)
        {
            var dbRole = Find(id);
            if (dbRole == null)
                throw new System.Exception("This role is not found");

            db.Roles.Remove(dbRole);
            return db.SaveChanges() > 0;
        }

        public Role Find(int id)
        {
            return db.Roles.Find(id);
        }


        public List<Role> Find()
        {
            return db.Roles.ToList();
            
        }

        public List<Role> Find(string role)
        {
            var data = (from r in db.Roles
                          where r.Name.ToLower().Contains(role.ToLower())
                          select r).ToList();

            return data;
        }

        public bool Update(Role entity)
        {
            var dbObj = Find(entity.Id);

            if (dbObj == null)
                return false;

            dbObj.Id = entity.Id;
            dbObj.Name = entity.Name;
            return db.SaveChanges() > 0;
        }
    }
}
