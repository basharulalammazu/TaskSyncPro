using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TaskSyncDbContext db;
        protected readonly DbSet<T> table;

        public Repository(TaskSyncDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public T Find(int id)
        {
            return table.Find(id);
        }

        public List<T> Find()
        {
            return table.ToList();
        }

        public bool Create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(T obj)
        {
            var entry = db.Entry(obj);

            var key = entry.Metadata.FindPrimaryKey();
            if (key == null || key.Properties.Count != 1)
            {
                table.Update(obj);
                return db.SaveChanges() > 0;
            }

            var keyProperty = key.Properties[0];
            var keyValue = entry.Property(keyProperty.Name).CurrentValue;

            var existing = table.Find(keyValue);
            if (existing == null)
                return false;

            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var entity = Find(id);
            if (entity == null)
                return false;

            table.Remove(entity);
            return db.SaveChanges() > 0;
        }
    }
}