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
                throw new Exception("Invalid billing amount");

            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<BillingRecord>(billingRecordDTO);

            return dataAccessFactory.BillingDataAccess().Create(data);
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.BillingDataAccess().Delete(id);
        }

        public BillingRecordDTO Find(int id)
        {
            var data = dataAccessFactory.BillingDataAccess().Find(id);
            
            if (data == null)
               return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<BillingRecordDTO>(data);
        }

        public List<BillingRecordDTO> Find()
        {
            var data = dataAccessFactory.BillingDataAccess().Find();

            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BillingRecordDTO>>(data);
        }

        public bool Update(BillingRecordDTO billingRecordDTO)
        {
            if (billingRecordDTO.Amount <= 0)
                throw new ArgumentException("Billing amount must be greater than zero.");

            try
            {
                var mapper = MapperConfig.GetMapper();
                var data = mapper.Map<BillingRecord>(billingRecordDTO);

                return dataAccessFactory.BillingDataAccess().Update(data);
            }
            catch (KeyNotFoundException ex)
            {
                throw new ApplicationException("Billing record does not exist.", ex);
            }
        }



        public List<BillingRecordDTO> GetBillingRecordsWithTask()
        {
            var data = dataAccessFactory.BillingDataAccess().GetBillingRecordsWithTask();
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<BillingRecordDTO>>(data);
        }

        public BillingRecordDTO GetBillingRecordWithTask(int id)
        {
            var data = dataAccessFactory.BillingDataAccess().GetBillingRecordWithTask(id);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<BillingRecordDTO>(data);
        }
    }
}
