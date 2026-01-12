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
        DataAccessFactory dataAccessFactory;
        public TaskService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public (bool IsSuccess, string ErrorMessage) Create(TaskDTO taskDTO)
        {
            
            try
            {
                var mapper = MapperConfig.GetMapper();
                var task = mapper.Map<DAL.EF.Models.Task>(taskDTO);
                var success = dataAccessFactory.TaskDataAccess().Create(task);
                return (success, null);
            }
            catch (ValidationException ex)
            {
                return (false, ex.Message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
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

        public TaskDTO GetTasksByPriority(string priority)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTasksByPriority(priority);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskDTO>(data);
        }

        public TaskDTO GetTasksWithEmployee(string employee)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTasksWithEmployee(employee);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskDTO>(data);
        }

        public TaskDTO GetTaskWithEmployee(int id)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTaskWithEmployee(id);

            if (data == null || data.Count == 0)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskDTO>(data[0]);


        }

        public bool Update(TaskDTO entity)
        {
            var mapper = MapperConfig.GetMapper();
            var task = mapper.Map<DAL.EF.Models.Task>(entity);
            return dataAccessFactory.TaskDataAccess().Update(task);
        }
    }
}
