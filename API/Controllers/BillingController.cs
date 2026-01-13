using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly BillingService service;

        public BillingController(DataAccessFactory dataAccessFactory)
        {
            service = new BillingService(dataAccessFactory);
        }

        // CREATE
        [HttpPost("create")]
        public IActionResult Create(BillingRecordDTO billingRecordDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Create(billingRecordDTO);
                if (!result)
                    return BadRequest(new { Message = "Failed to create billing record." });

                return Ok(new { Message = "Billing record created successfully", Success = result });
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
            var data = service.Find();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No billing records found." });

            return Ok(data);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Find(id);
            if (data == null)
                return NotFound(new { Message = "Billing record not found." });

            return Ok(data);
        }

        // UPDATE
        [HttpPut("update")]
        public IActionResult Update(BillingRecordDTO billingRecordDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = service.Update(billingRecordDTO);

                if (!result)
                    return BadRequest(new { Message = "Failed to update billing record." });

                return Ok(new { Message = "Billing record updated successfully", Success = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result)
                return NotFound(new { Message = "Billing record not found or not deleted." });
            
            return Ok(new { Message = "Billing record deleted successfully", Success = result });
            
        }

        // GET ALL WITH TASK
        [HttpGet("withTask")]
        public IActionResult GetBillingRecordsWithTask()
        {
            var data = service.GetBillingRecordsWithTask();
            if (data == null || data.Count == 0)
                return NotFound(new { Message = "No billing records with tasks found." });

            return Ok(data);
        }

        // GET SINGLE WITH TASK
        [HttpGet("withTask/{id}")]
        public IActionResult GetBillingRecordWithTask(int id)
        {
            var data = service.GetBillingRecordWithTask(id);
            if (data == null)
                return NotFound(new { Message = "Billing record with task not found." });

            return Ok(data);

        }
    }
}
