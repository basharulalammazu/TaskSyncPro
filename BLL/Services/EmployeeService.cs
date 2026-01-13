using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService
    {
        private readonly DataAccessFactory dataAccessFactory;

        public EmployeeService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }

        public bool Create(EmployeeDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var mapper = MapperConfig.GetMapper();
                var dbEntity = mapper.Map<Employee>(entity);

                return dataAccessFactory.EmployeeDataAccess().Create(dbEntity);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Employee creation failed.", ex);
            }
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.EmployeeDataAccess().Delete(id);
        }

        public EmployeeDTO Find(int id)
        {
            var data = dataAccessFactory.EmployeeDataAccess().Find(id);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EmployeeDTO>(data);
        }

        public List<EmployeeDTO> Find()
        {
            var data = dataAccessFactory.EmployeeDataAccess().Find();
            if (data == null || data.Count == 0)
                return new List<EmployeeDTO>();

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<EmployeeDTO>>(data);
        }

        public EmployeeDTO FindByUserEmail(string email)
        {
            var data = dataAccessFactory.EmployeeDataAccess().FindByUserEmail(email);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EmployeeDTO>(data);
        }

        public List<EmployeeDTO> GetEmployeesWithTasks()
        {
            var data = dataAccessFactory.EmployeeDataAccess().GetEmployeesWithTasks();
            if (data == null || data.Count == 0)
                return new List<EmployeeDTO>();

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<EmployeeDTO>>(data);
        }

        public EmployeeDTO GetEmployeeWithTasks(int id)
        {
            var data = dataAccessFactory.EmployeeDataAccess().GetEmployeeWithTasks(id);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EmployeeDTO>(data);
        }

        public bool Update(EmployeeDTO entity)
        {
            var mapper = MapperConfig.GetMapper();
            var dbEntity = mapper.Map<Employee>(entity);
            return dataAccessFactory.EmployeeDataAccess().Update(dbEntity);
        }
    }
}
