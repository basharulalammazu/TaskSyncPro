using BLL.DTOs;
using BLL.Services;
using DAL.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService service;

        public TaskController(TaskService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(TaskDTO task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                service.Create(task);
                return Ok(new { Message = "Task created successfully." });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }





        [HttpGet("all/{id}")]
        public IActionResult Find(int id)
        {
            var data = service.Find(id);
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "Task not found." });
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Find();
            if (data.Count == 0)
                return NotFound(new { Message = "No tasks found." });

            if (data == null)
                return BadRequest(new { Message = "Something is wrong." });

            return Ok(data);
        }

        [HttpPut("update")]
        public IActionResult Update(TaskDTO entity)
        {
            if (entity == null)
                return BadRequest(new { Message = "Invalid employee data." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Update(entity);
                if (result)
                    return Ok(new { Message = "Task updated successfully." });

                return BadRequest(new { Message = "Task is not updated." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                // Handles duplicate or business errors
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception)
            {
                // Any unexpected errors
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result)
                return Ok(new { Message = "Task deleted successfully." });

            return BadRequest(new { Message = "Task is not deleted." });
        }

        [HttpGet("findByTitle/{title}")]
        public IActionResult FindByTitle(string title)
        {
            var data = service.GetTaskByTitle(title);
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "No tasks found." });
        }

        [HttpGet("findByPriority/{priority}")]
        public IActionResult FindByPriority(string priority)
        {
            var data = service.GetTasksByPriority(priority);
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "No tasks found." });
        }

        [HttpGet("findWithEmployee")]
        public IActionResult FindWithEmployee()
        {
            var data = service.GetTasksWithEmployee();
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "No tasks found." });
        }

        [HttpGet("findEmployeeTask/{id}")]
        public IActionResult FindEmployeeTask(int id)
        {
            var data = service.GetTaskWithEmployee(id);
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "Task not found." });
        }

        
    }
}