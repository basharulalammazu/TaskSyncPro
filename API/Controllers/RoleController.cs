using BLL;
using BLL.DTOs;
using BLL.Services;
using DAL;
using DAL.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleService service;

        public RoleController(RoleService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public IActionResult Create(RoleDTO role)
        {
           // Console.WriteLine(role.Name);
            if (role == null)
                return BadRequest(new { Message = "Invalid role data." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = service.Create(role);

            if (!result)
                return Conflict(new { Message = "Role already exists." }); // 409 Conflict

            return Ok(new { Message = "Role created successfully." });
        }



        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result)
                return Ok(new { Message = "Role deleted successfully." });
            return BadRequest(new { Message = "Role is not deleted." });
        }

        [HttpGet("Find/{id}")]
        public IActionResult Find(int id)
        {
            var data = service.Find(id);
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "Role not found." });
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Find();
            if (data != null)
                return Ok(data);

            return NotFound(new { Message = "No roles found." });
        }

        [HttpGet("byName/{role}")]
        public IActionResult Find(string role)
        {
            var data = service.Find(role);
            if (data != null)
                return Ok(data);
            return NotFound(new { Message = "No roles found." });

        }

        [HttpPut("update")]
        public IActionResult Update(Role entity)
        {
            var result = service.Update(entity);
            if (result)
                return Ok(new { Message = "Role updated successfully." });
            return BadRequest(new { Message = "Role is not updated." });
        }
    }
}
