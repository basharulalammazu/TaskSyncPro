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


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            var user = service.LoginAsync(dto);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(user);
        }


        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Find();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No users found." });

            return Ok(data);
        }


        [HttpGet("all/{id}")]
        public IActionResult AllByID(int id)
        {
            var data = service.Find(id);
            if (data == null)
                return NotFound(new { Message = "No user found." });

            return Ok(data);
        }


        [HttpPost("create")]
        public IActionResult Create(UserDTO user)
        {
            if (user == null)
                return BadRequest(new { Message = "Invalid user data." });

            ModelState.Remove(nameof(UserDTO.Password));

            if (!ModelState.IsValid)
                return BadRequest(new { Message = ModelState });

            try
            {
                var data = service.Create(user);

                if (!data )
                    return BadRequest(new { Message = "User could not be created." });

                return Ok(new { Message = "User created successfully." });
            }
            catch (ApplicationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { Message = "User data is required." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = service.Delete(id);

                if (result)
                    return Ok(new { Message = "User deleted successfully." });


                return BadRequest(new { Message = "User is not delete." });
            }

            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }

        [HttpPut("update")]
        public IActionResult Update(UserDTO user)
        {

            if (user == null)
                return BadRequest(new { Message = "Invalid user data." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Update(user);

                if (result)
                    return Ok(new { Message = "User data updated successfully." });


                return BadRequest(new { Message = "User data is not updated." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }


        [HttpGet("byEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var data = service.FindByEmail(email);
            if (data == null)
                return NotFound(new { Message = "No user found with the provided email." });

            return Ok(data);
        }


        [HttpGet("byPhoneNumber/{phoneNumber}")]
        public IActionResult GetByPhoneNumber(string phoneNumber)
        {
            var data = service.FindByPhoneNumber(phoneNumber);
            if (data == null)
                return NotFound(new { Message = "No user found with the provided phone number." });

            return Ok(data);
        }

        [HttpGet("withRoles")]
        public IActionResult GetUsersWithRoles()
        {
            var data = service.GetUsersWithRole();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No users found." });

            return Ok(data);
        }
    }
}
