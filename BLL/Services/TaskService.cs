using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TaskService
    {
        private static readonly List<string> AllowedStatuses = new List<string> {"Pending", "InProgress","Completed","Overdue"};
        private static readonly List<string> AllowedPriorities = new List<string> {"Low", "Medium", "High"};


        DataAccessFactory dataAccessFactory;
        public TaskService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public bool Create(TaskDTO taskDTO)
        {
            if (taskDTO == null)
                throw new ArgumentNullException(nameof(taskDTO), "Task data is required.");

            if (!AllowedStatuses.Contains(taskDTO.Status))
                throw new ApplicationException("Invalid status. Allowed values: Pending, InProgress, Completed, Overdue.");

            if (!AllowedPriorities.Contains(taskDTO.Priority))
                throw new ApplicationException("Invalid priority. Allowed values: Low, Medium, High.");

            try
            {
                var mapper = MapperConfig.GetMapper();
                var task = mapper.Map<DAL.EF.Models.Task>(taskDTO);

                return dataAccessFactory.TaskDataAccess().Create(task);
            }
            catch 
            {
                throw;
            }
           
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.TaskDataAccess().Delete(id);
        }

        public TaskDTO Find(int id)
        {
            var data = dataAccessFactory.TaskDataAccess().Find(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskDTO>(data);

        }

        public List<TaskDTO> Find()
        {
            var data = dataAccessFactory.TaskDataAccess().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);

        }

        public List<TaskDTO> GetTaskByTitle(string title)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTaskByTitle(title);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);
        }

        public List<TaskDTO> GetTasksByPriority(string priority)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTasksByPriority(priority);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);
        }


        public List<TaskDTO> GetTasksWithEmployee()
        {
            var data = dataAccessFactory.TaskDataAccess().GetTasksWithEmployee();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);
        }


        public List<TaskDTO> GetTaskWithEmployee(int id)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTaskWithEmployee(id);

            if (data == null || data.Count == 0)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);


        }

        public bool Update(TaskDTO entity)
        {
            var mapper = MapperConfig.GetMapper();
            var task = mapper.Map<DAL.EF.Models.Task>(entity);
            return dataAccessFactory.TaskDataAccess().Update(task);
        }
    }
}
