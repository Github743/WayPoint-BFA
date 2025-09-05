using Microsoft.AspNetCore.Mvc;
using WayPoint_Infrastructure.Interfaces;
using WayPoint_Models;

namespace WayPoint_BFA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountScheduleController(ISystemDiscountRepository service) : ControllerBase
    {
        private readonly ISystemDiscountRepository _service = service;

        [HttpGet("GetDiscountSchedules")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountScheduleDto>>> GetDiscountSchedules(
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
