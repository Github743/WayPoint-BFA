using BFAWebApp.Domain.ReadModels;
using BFAWebApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BFAWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountScheduleController(SystemDiscountRepository service) : ControllerBase
    {
        private readonly SystemDiscountRepository _service = service;

        [HttpGet("GetDiscountSchedules")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountSchedule>>> GetDiscountSchedules(
            [FromQuery] int workOrderId,
            [FromQuery] int systemDiscountProgramId,
            CancellationToken ct)
        {
            if (workOrderId <= 0) return BadRequest("workOrderId must be > 0");
            var rows = await _service.GetDiscountSchedulesAsync(workOrderId, systemDiscountProgramId, ct);
            return Ok(rows);
        }
    }
}
