using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BillingService
    {
        DataAccessFactory dataAccessFactory;

        public BillingService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public bool Create(BillingRecordDTO billingRecordDTO)
        {
            if (billingRecordDTO.Amount <= 0)
                throw new Exception("Billing amount must be greater than zero.");

            if (dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(billingRecordDTO.TaskId) == null)
                throw new Exception("Invalid TaskId. Task does not exist.");

            if (dataAccessFactory.GetRepo<User>().Find(billingRecordDTO.PaidById) == null)
                throw new Exception("Invalid PaidById. Employee does not exist.");


            if (dataAccessFactory.BillingDataAccess().GetBillingRecordsByTask(billingRecordDTO.TaskId) != null)
                throw new Exception("Billing record for this TaskId already exists.");

            

            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<BillingRecord>(billingRecordDTO);

            return dataAccessFactory.GetRepo<BillingRecord>().Create(data);
        }

        public BillingRecordDTO Find(int id)
        {
            var data = dataAccessFactory.GetRepo<BillingRecord>().Find(id);
            
            if (data == null)
               return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<BillingRecordDTO>(data);
        }

        public List<BillingRecordDTO> Find()
        {
            var data = dataAccessFactory.GetRepo<BillingRecord>().Find();

            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BillingRecordDTO>>(data);
        }

        public bool Update(BillingRecordDTO billingRecordDTO)
        {
            if (billingRecordDTO.Amount <= 0)
                throw new ArgumentException("Billing amount must be greater than zero.");

            if (dataAccessFactory.GetRepo<BillingRecord>().Find(billingRecordDTO.TaskId) == null)
                throw new KeyNotFoundException("Billing record not found.");

            if (dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(billingRecordDTO.TaskId) == null)
                throw new Exception("Invalid TaskId. Task does not exist.");


                var mapper = MapperConfig.GetMapper();
                var data = mapper.Map<BillingRecord>(billingRecordDTO);

                return dataAccessFactory.GetRepo<BillingRecord>().Update(data);

        }


        public bool Delete(int id)
        {
            if (Find(id) == null)
                throw new KeyNotFoundException("Billing record not found.");

            return dataAccessFactory.GetRepo<BillingRecord>().Delete(id);
        }


        public List<BillingTaskDTO> GetBillingRecordsWithTask()
        {
            var data = dataAccessFactory.BillingDataAccess().GetBillingRecordsWithTask();
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BillingTaskDTO>>(data);
        }

        public BillingTaskDTO GetBillingRecordWithTask(int id)
        {
            var data = dataAccessFactory.BillingDataAccess().GetBillingRecordWithTask(id);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<BillingTaskDTO>(data);
        }
    }
}
