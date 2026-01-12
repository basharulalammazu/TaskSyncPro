using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService service;
        public UserController(UserService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Find();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult AllByID(int id)
        {
            return Ok(service.Find(id));
        }


        [HttpPost("create")]
        public IActionResult Create(UserDTO user)
        {
            var result = service.Create(user);

            if (!result.IsSuccess)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(new { Message = "User created successfully." });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);

            if (result)
                return Ok(new { Message = "User deleted successfully." });


            return BadRequest(new { Message = "User is not delete." });
        }

        [HttpPost("update")]
        public IActionResult Update(UserDTO user)
        {
            var result = service.Update(user);

            if (result)
                return Ok(new { Message = "User data updated successfully." });


            return BadRequest(new { Message = "User data is not updated." });
        }


    }
}
