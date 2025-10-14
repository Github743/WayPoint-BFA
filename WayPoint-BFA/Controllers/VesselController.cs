using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [ApiController]
    [Route("api")]
    public class VesselController(IVesselRepository vesselRepo) : ControllerBase
    {
        private readonly IVesselRepository _vesselRepo = vesselRepo;
        [HttpGet("vessels")]
        public async Task<ActionResult<IReadOnlyList<Vessel>>> GetVessels([FromQuery] string? clientSearch, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(clientSearch)) return BadRequest("Search text is mandaotry");
            var rows = await vesselRepo.GetVessels(clientSearch, ct);
            return Ok(rows);
        }
    }
}
