using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService service;

        public TeamController(DataAccessFactory dataAccessFactory)
        {
            service = new TeamService(dataAccessFactory);
        }

        // CREATE
        [HttpPost("create")]
        public IActionResult Create(TeamDTO teamDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Create(teamDTO);
                if (!result)
                    return BadRequest(new { Message = "Failed to create team." });

                return Ok(new { Message = "Team created successfully"});
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

                if (data == null)
                    return BadRequest(new { Message = "Something is wrong" });

                if (data.Count == 0)
                    return NotFound(new { Message = "No teams found" });

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
                    return NotFound(new { Message = "Team not found" });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // UPDATE
        [HttpPut("update")]
        public IActionResult Update(TeamDTO teamDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Update(teamDTO);
                if (!result)
                    return BadRequest(new { Message = "Failed to update team." });

                return Ok(new { Message = "Team updated successfully", Success = result });
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
                return Ok(new { Message = "Team deleted successfully", Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET TEAMS WITH EMPLOYEES
        [HttpGet("withEmployees")]
        public IActionResult GetTeamsWithEmployees()
        {
                var data = service.GetTeamsWithEmployees();
            if (data == null)
                return BadRequest(new { Message = "Something is wrong" });

            if (data.Count == 0)
                return NotFound(new { Message = "No teams with employees found" });
            
            return Ok(data);
        }

        [HttpGet("withEmployees/{id}")]
        public IActionResult GetTeamsWithEmployees(int id)
        {
            var data = service.GetTeamsWithEmployees(id);
            if (data == null)
                return NotFound(new { Message = "No teams with employees found" });

            return Ok(data);
        }
    }
}