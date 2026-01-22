using BLL.DTOs;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportsService service;

        public ReportsController(DataAccessFactory dataAccessFactory)
        {
            service = new ReportsService(dataAccessFactory);
        }

        private static bool IsValidRange(DateRangeDTO range)
        {
            return range != null && range.From != default && range.To != default && range.From <= range.To;
        }

        // GET TASK STATUS OVERVIEW
        [HttpPost("task-status-overview")]
        public IActionResult TaskStatusOverview(DateRangeDTO range)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!IsValidRange(range))
                return BadRequest(new { Message = "Invalid date range. Ensure 'From' and 'To' are provided and From <= To." });

            try
            {
                var result = service.TaskStatusOverview(range);
                if (result == null)
                    return NotFound(new { Message = "No data found for the given date range." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET TASK PRIORITY OVERVIEW
        [HttpPost("task-priority-overview")]
        public IActionResult TaskPriorityOverview(DateRangeDTO range)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!IsValidRange(range))
                return BadRequest(new { Message = "Invalid date range. Ensure 'From' and 'To' are provided and From <= To." });
            try
            {
                var result = service.TaskPriorityOverview(range);
                if (result == null)
                    return NotFound(new { Message = "No data found for the given date range." });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        // GET EMPLOYEE PERFORMANCE
        [HttpPost("employee-performance")]
        public IActionResult EmployeePerformance(DateRangeDTO range)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!IsValidRange(range))
                return BadRequest(new { Message = "Invalid date range. Ensure 'From' and 'To' are provided and From <= To." });

            try
            {
                var result = service.EmployeePerformance(range);
                if (result == null || !result.Any())
                    return NotFound(new { Message = "No data found for the given date range." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        // Team Performance
        [HttpPost("team-performance")]
        public IActionResult TeamPerformance(DateRangeDTO range)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!IsValidRange(range))
                return BadRequest(new { Message = "Invalid date range. Ensure 'From' and 'To' are provided and From <= To." });
            try
            {
                var result = service.TeamPerformance(range);
                if (result == null || !result.Any())
                    return NotFound(new { Message = "No data found for the given date range." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }
    }
}
