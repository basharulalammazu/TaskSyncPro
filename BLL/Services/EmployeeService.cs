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

            if (dataAccessFactory.GetRepo<User>().Find(entity.UserId) == null)
                throw new ArgumentException("Invalid UserId: User does not exist.");

            if (dataAccessFactory.GetRepo<Team>().Find(entity.TeamId) == null)
                throw new ArgumentException("Invalid TeamId: Team does not exist.");

            // Check if the User already has an Employee
            if (dataAccessFactory.EmployeeDataAccess().ExistsForUser(entity.UserId))
                throw new InvalidOperationException("Employee already exists for this user.");

            // Check if the Team already has the same Designation
            if (dataAccessFactory.EmployeeDataAccess().ExistsForTeamDesignation(entity.TeamId, entity.Designation))
                throw new InvalidOperationException("Duplicate designation in the same team.");
           
            var mapper = MapperConfig.GetMapper();
            var dbEntity = mapper.Map<Employee>(entity);

            return dataAccessFactory.GetRepo<Employee>().Create(dbEntity);

        }


        public EmployeeDTO Find(int id)
        {
            var data = dataAccessFactory.GetRepo<Employee>().Find(id);
            if (data == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EmployeeDTO>(data);
        }

        public List<EmployeeDTO> Find()
        {
            var data = dataAccessFactory.GetRepo<Employee>().Find();
            if (data == null || data.Count == 0)
                return new List<EmployeeDTO>();

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<EmployeeDTO>>(data);
        }

        public bool Update(EmployeeDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (dataAccessFactory.GetRepo<User>().Find(entity.UserId) == null)
                throw new ArgumentException("Invalid UserId: User does not exist.");

            if (dataAccessFactory.GetRepo<Team>().Find(entity.TeamId) == null)
                throw new ArgumentException("Invalid TeamId: Team does not exist.");


            var mapper = MapperConfig.GetMapper();
            var dbEntity = mapper.Map<Employee>(entity);
            return dataAccessFactory.GetRepo<Employee>().Update(dbEntity);
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.GetRepo<Employee>().Delete(id);
        }

        /*
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

        */
        public List<EmployeeDetailsDTO> GetEmployeeWithDetails()
        {
            var data = dataAccessFactory.EmployeeDataAccess().GetEmployeeWithDetails();
            if (data == null)
                return null;
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<EmployeeDetailsDTO>>(data);
        }


        public EmployeeDetailsDTO GetEmployeeWithDetails(int id)
        {
            var data = dataAccessFactory.EmployeeDataAccess().GetEmployeeWithDetails(id);
            if (data == null)
                return null;
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EmployeeDetailsDTO>(data);
        }

    }
}
