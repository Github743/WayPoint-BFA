using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientAgreementController(ISystemDiscountRepository systemDiscountRepository) : ControllerBase
    {
        private readonly ISystemDiscountRepository _systemDiscountRepository = systemDiscountRepository;

        [HttpGet("schedules")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountSchedules>>> GetDiscountSchedules([FromQuery] int workOrderId, int systemDiscountProgramId,  CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetDiscountSchedules(workOrderId, systemDiscountProgramId, ct);
            return Ok(rows);
        }

        [HttpGet("schedule-products")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountScheduleProducts>>> GetDiscountScheduleProducts([FromQuery] int systemDiscountScheduleId, CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetDiscountScheduleProducts(systemDiscountScheduleId, ct);
            return Ok(rows);
        }

        [HttpGet("systemproducts-discountbyname")]
        public async Task<ActionResult<IReadOnlyList<SystemProductDiscountGroup>>> GetSystemProductDiscountGroupByName([FromQuery] string systemProductName, CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetSystemProductDiscountGroupByName(systemProductName, ct);
            return Ok(rows);
        }
    }
}
