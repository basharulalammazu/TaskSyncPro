using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TaskLogService
    {
        DataAccessFactory dataAccessFactory;

        public TaskLogService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }

        public bool Create(TaskLogDTO taskLogDTO)
        {
            if (dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(taskLogDTO.TaskItemId) == null)
                throw new ArgumentException($"Task with ID {taskLogDTO.TaskItemId} does not exist.");

            if (taskLogDTO.ChangedAt > DateTime.Now)
                throw new ArgumentException("ChangedAt cannot be in the future.");

            if (dataAccessFactory.TaskLogDataAccess().TaskLogExists(0, taskLogDTO.TaskItemId))
                throw new ArgumentException($"A TaskLog for TaskItemId {taskLogDTO.TaskItemId} already exists.");


            var mapper = MapperConfig.GetMapper();
            var taskLog = mapper.Map<TaskLog>(taskLogDTO);
            return dataAccessFactory.GetRepo<TaskLog>().Create(taskLog);
        }



        public TaskLogDTO Find(int id)
        {
            var dbData = dataAccessFactory.GetRepo<TaskLog>().Find(id);
            if (dbData == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskLogDTO>(dbData);
        }


        public List<TaskLogDTO> Find()
        {
            var dbData = dataAccessFactory.GetRepo<TaskLog>().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskLogDTO>>(dbData);
        }

        public bool Update(TaskLogDTO taskLogDTO)
        {
            if (Find(taskLogDTO.Id) == null)
                throw new ArgumentException($"TaskLog with ID {taskLogDTO.Id} does not exist.");

            if (dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(taskLogDTO.TaskItemId) == null)
                throw new ArgumentException($"Task with ID {taskLogDTO.TaskItemId} does not exist.");

            if (taskLogDTO.ChangedAt > DateTime.Now)
                throw new ArgumentException("ChangedAt cannot be in the future.");

            if (Find(taskLogDTO.Id).ChangedAt > taskLogDTO.ChangedAt)
                throw new ArgumentException("ChangedAt cannot be earlier than the existing record's ChangedAt.");

            if (dataAccessFactory.TaskLogDataAccess().TaskLogExists(taskLogDTO.Id, taskLogDTO.TaskItemId))
                throw new ArgumentException($"A TaskLog for TaskItemId {taskLogDTO.TaskItemId} already exists.");

            var mapper = MapperConfig.GetMapper();
            var taskLog = mapper.Map<TaskLog>(taskLogDTO);
            return dataAccessFactory.GetRepo<TaskLog>().Update(taskLog);
        }


        public bool Delete(int id)
        {
            if (Find(id) == null)
                throw new ArgumentException($"TaskLog with ID {id} does not exist.");

            return dataAccessFactory.GetRepo<TaskLog>().Delete(id);
        }

        public List<TaskLogDTO> GetTaskLogsByTaskId(int taskId)
        {
            var dbData = dataAccessFactory.TaskLogDataAccess().GetTaskLogsByTaskId(taskId);
            if (dbData == null || dbData.Count == 0)
                return new List<TaskLogDTO>(); 

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskLogDTO>>(dbData);
        }

    }
}
