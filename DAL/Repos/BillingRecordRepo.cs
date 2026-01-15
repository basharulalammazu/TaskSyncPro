using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class BillingRecordRepo : IBillingFeature
    {
        private readonly TaskSyncDbContext db;
        public BillingRecordRepo(TaskSyncDbContext db) 
        { 
            this.db = db; 
        }

        public List<BillingRecord> GetBillingRecordsWithTask()
        {
            return db.BillingRecords.Include(b => b.Task).ToList();
        }

        public BillingRecord GetBillingRecordWithTask(int id)
        {
            return db.BillingRecords.Include(b => b.Task).FirstOrDefault(b => b.Id == id);
        }
    }
}
