using BLL.DTOs;
using DAL;
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
            var mapper = MapperConfig.GetMapper();
            var taskLog = mapper.Map<DAL.EF.Models.TaskLog>(taskLogDTO);
            return dataAccessFactory.TaskLogDataAccess().Create(taskLog);
        }

        public bool Delete(int id)
        {
            return dataAccessFactory.TaskLogDataAccess().Delete(id);
        }

        public TaskLogDTO Find(int id)
        {
            var dbData = dataAccessFactory.TaskLogDataAccess().Find(id);
            if (dbData == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskLogDTO>(dbData);
        }


        public List<TaskLogDTO> Find()
        {
            var dbData = dataAccessFactory.TaskLogDataAccess().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskLogDTO>>(dbData);
        }

        public bool Update(TaskLogDTO taskLogDTO)
        {
            var mapper = MapperConfig.GetMapper();
            var taskLog = mapper.Map<DAL.EF.Models.TaskLog>(taskLogDTO);
            return dataAccessFactory.TaskLogDataAccess().Update(taskLog);
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
