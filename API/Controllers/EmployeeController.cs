using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService service;

        public EmployeeController(EmployeeService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                service.Create(employee);

                return Ok(new { Message = "Employee created successfully." });
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { Message = "Employee data is required." });
            }
            catch (ApplicationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result)
                return NotFound(new { Message = "Employee not found or not deleted." });

            return Ok(new { Message = "Employee deleted successfully." });
        }

        [HttpGet("all/{id}")]
        public IActionResult Find(int id)
        {
            var data = service.Find(id);
            if (data == null)
                return NotFound(new { Message = "Employee not found." });

            return Ok(data);
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Find();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No employees found." });

            return Ok(data);
        }

        /*

        [HttpGet("ByEmail/{email}")]
        public IActionResult FindByUserEmail(string email)
        {
            var data = service.FindByUserEmail(email);
            if (data == null)
                return NotFound(new { Message = "Employee not found." });

            return Ok(data);
        }
        

        [HttpGet("WithTasks")]
        public IActionResult GetEmployeesWithTasks()
        {
            var data = service.GetEmployeesWithTasks();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No employees found." });

            return Ok(data);
        }

        

        [HttpGet("WithTasks/{id}")]
        public IActionResult GetEmployeeWithTasks(int id)
        {
            var data = service.GetEmployeeWithTasks(id);
            if (data == null)
                return NotFound(new { Message = "Employee not found." });

            return Ok(data);
        }
        */

        [HttpPut("update")]
        public IActionResult Update(EmployeeDTO employee)
        {
            if (employee == null)
                return BadRequest(new { Message = "Invalid employee data." });

            try
            {
                var result = service.Update(employee);
                if (!result)
                    return NotFound(new { Message = "Employee not found or not updated." });

                return Ok(new { Message = "Employee updated successfully." });
            }
            catch (InvalidOperationException ex)
            {
                // For things like "User does not exist" or "Team does not exist"
                return BadRequest(new { Message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                // For duplicate employee issues
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Generic unexpected errors
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }



        [HttpGet("GetEmployeeWithDetails")]
        public IActionResult GetEmployeeWithDetails()
        {
            var data = service.GetEmployeeWithDetails();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No employees found." });

            return Ok(data);
        }

        [HttpGet("GetEmployeeWithDetails/{id}")]
        public IActionResult GetEmployeeWithDetails(int id)
        {
            var data = service.GetEmployeeWithDetails(id);
            if (data == null)
                return NotFound(new { Message = "Employee not found." });
            return Ok(data);
        }
    }
}
