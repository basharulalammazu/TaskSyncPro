using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class BillingRecordRepo : IRepository<BillingRecord>, IBillingFeature
    {
        private readonly TaskSyncDbContext db;
        public BillingRecordRepo(TaskSyncDbContext db) 
        { 
            this.db = db; 
        }

        public bool Create(BillingRecord br) 
        { 

            db.BillingRecords.Add(br);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Find(id);
            if (ex == null) 
                return false;

            db.BillingRecords.Remove(ex);
            return db.SaveChanges() > 0;
        }


        public BillingRecord Find(int id) 
        { 
            return db.BillingRecords.Find(id); 
        }

        public List<BillingRecord> Find() 
        { 
            return db.BillingRecords.ToList(); 
        }

        public bool Update(BillingRecord br)
        {
            var ex = Find(br.Id);
            if (ex == null)
                throw new KeyNotFoundException("Billing record not found.");

            db.Entry(ex).CurrentValues.SetValues(br);
            return db.SaveChanges() > 0;
        }


        public List<BillingRecord> GetBillingRecordsWithTask()
        {
            return db.BillingRecords.Include(b => b.Task).ToList();
        }

        public BillingRecord GetBillingRecordWithTask(int id)
        {
            return db.BillingRecords.Include(b => b.Task)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
