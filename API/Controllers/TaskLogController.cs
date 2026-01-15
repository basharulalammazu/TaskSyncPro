using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskLogController : ControllerBase
    {
        private readonly TaskLogService service;

        public TaskLogController(DataAccessFactory dataAccessFactory)
        {
            service = new TaskLogService(dataAccessFactory);
        }

        // CREATE
        [HttpPost("create")]
        public IActionResult Create(TaskLogDTO taskLogDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Create(taskLogDTO);
                return Ok(new { Message = "Task log created successfully", Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET ALL
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var data = service.Find();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET BY ID
        [HttpGet("all/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = service.Find(id);
                if (data == null)
                    return NotFound(new { Message = "Task log not found" });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // UPDATE
        [HttpPut("update")]
        public IActionResult Update(TaskLogDTO taskLogDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Update(taskLogDTO);
                return Ok(new { Message = "Task log updated successfully", Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = service.Delete(id);
                return Ok(new { Message = "Task log deleted successfully", Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET BY TASK ID
        [HttpGet("byTask/{taskId}")]
        public IActionResult GetByTaskId(int taskId)
        {
            try
            {
                var data = service.GetTaskLogsByTaskId(taskId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
