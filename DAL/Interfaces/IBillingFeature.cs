using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBillingFeature : IRepository<BillingRecord>
    {
        List<BillingRecord> GetBillingRecordsWithTask();
        BillingRecord GetBillingRecordWithTask(int id);
    }
}
