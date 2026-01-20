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

        private void ValidateTask(TaskDTO taskDTO, bool isUpdate = false)
        {
            if (taskDTO == null)
                throw new ArgumentNullException(nameof(taskDTO), "Task data is required.");

            if (!AllowedStatuses.Contains(taskDTO.Status))
                throw new ApplicationException("Invalid status. Allowed values: Pending, InProgress, Completed, Overdue.");

            if (!AllowedPriorities.Contains(taskDTO.Priority))
                throw new ApplicationException("Invalid priority. Allowed values: Low, Medium, High.");

            if (taskDTO.DueDate < taskDTO.CreatedAt)
                throw new ApplicationException("Due date cannot be earlier than creation date.");

            if (taskDTO.Status == "Completed" && taskDTO.CompletedAt == null)
                throw new ApplicationException("Completed tasks must have a completion date.");

            if (taskDTO.Status != "Completed" && taskDTO.CompletedAt != null)
                throw new ApplicationException("Only completed tasks can have a completion date.");

            if (taskDTO.Status == "Overdue" && taskDTO.DueDate > DateTime.Now)
                throw new ApplicationException("A task cannot be marked as Overdue if its due date has not yet passed.");

            if (taskDTO.Status == "Completed" && taskDTO.CompletedAt > DateTime.Now)
                throw new ApplicationException("Completion date cannot be in the future.");

            if (taskDTO.CompletedAt != null && taskDTO.CompletedAt < taskDTO.CreatedAt)
                throw new ApplicationException("Completion date cannot be earlier than creation date.");

            if (taskDTO.AssignedEmployeeId != null && taskDTO.AssignedEmployeeId == taskDTO.CreatedBy)
                throw new ApplicationException("An employee cannot be assigned to a task they created.");

            if (taskDTO.Status == "InProgress" && taskDTO.AssignedEmployeeId == null)
                throw new ApplicationException("Tasks that are InProgress must be assigned to an employee.");

            if (taskDTO.Status == "Pending" && taskDTO.AssignedEmployeeId != null)
                throw new ApplicationException("Pending tasks cannot be assigned to an employee.");

            if (taskDTO.Title.Length > 100)
                throw new ApplicationException("Task title cannot exceed 100 characters.");

            if (taskDTO.Description != null && taskDTO.Description.Length > 500)
                throw new ApplicationException("Task description cannot exceed 500 characters.");
        }


        DataAccessFactory dataAccessFactory;
        public TaskService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public bool Create(TaskDTO taskDTO)
        {
            ValidateTask(taskDTO);

            if (dataAccessFactory.TaskDataAccess().SearchTaskByTitle(taskDTO.Title) != null)
                throw new ApplicationException("A task with the same title already exists.");

            if (taskDTO.AssignedEmployeeId != null)
            {
                var emp = dataAccessFactory.GetRepo<Employee>().Find(taskDTO.AssignedEmployeeId.Value);

                if (emp == null)
                    throw new ApplicationException("Create user does not exist.");

                if (dataAccessFactory.TaskDataAccess().ExistsForEmployee(taskDTO.Title, taskDTO.AssignedEmployeeId))
                    throw new ApplicationException("The assigned employee already has a task with the same title.");
            }

            
            if (dataAccessFactory.GetRepo<User>().Find(taskDTO.CreatedBy) == null && taskDTO.Status.ToLower() != "Pending")
                throw new ApplicationException("Creator employee does not exist.");
            
            var mapper = MapperConfig.GetMapper();
            var task = mapper.Map<DAL.EF.Models.Task>(taskDTO);

            return dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Create(task);
        }


        public TaskDTO Find(int id)
        {
            var data = dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TaskDTO>(data);

        }

        public List<TaskDTO> Find()
        {
            var data = dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);

        }

        public bool Update(TaskDTO taskDTO)
        {
            if (Find(taskDTO.Id) == null)
                throw new ApplicationException("Task not found.");

            ValidateTask(taskDTO, isUpdate: true);

            var existingTask = dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Find(taskDTO.Id);

            if (existingTask == null)
                throw new ApplicationException("Task not found.");

            // Prevent changing CreatedBy & CreatedAt
            taskDTO.CreatedBy = existingTask.CreatedBy;
            taskDTO.CreatedAt = existingTask.CreatedAt;

            // Duplicate title check (exclude current task)
            if (dataAccessFactory.TaskDataAccess().TitleExistsForOtherTask(taskDTO.Title, taskDTO.Id))
                throw new ApplicationException("Another task with the same title already exists.");

            if (taskDTO.AssignedEmployeeId != null)
            {
                var emp = dataAccessFactory.GetRepo<Employee>().Find(taskDTO.AssignedEmployeeId.Value);

                if (emp == null)
                    throw new ApplicationException("Assigned employee does not exist.");

                if (dataAccessFactory.TaskDataAccess().ExistsForEmployeeExcludingTask(taskDTO.Title, taskDTO.AssignedEmployeeId, taskDTO.Id))
                    throw new ApplicationException("The assigned employee already has a task with the same title.");
            }

            var mapper = MapperConfig.GetMapper();
            var updatedTask = mapper.Map<DAL.EF.Models.Task>(taskDTO);

            return dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Update(updatedTask);
        }


        public bool Delete(int id)
        {
            if (Find(id) == null)
                throw new ApplicationException("Task not found.");

            return dataAccessFactory.GetRepo<DAL.EF.Models.Task>().Delete(id);
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

        public List<TaskDTO> GetTasksByStatus(string status)
        {
            var data = dataAccessFactory.TaskDataAccess().GetTasksByStatus(status);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TaskDTO>>(data);
        }



    }
}
