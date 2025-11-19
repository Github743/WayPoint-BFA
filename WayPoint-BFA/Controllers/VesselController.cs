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
        public async Task<ActionResult<IReadOnlyList<VesselSearch>>> GetVessels([FromQuery] string? clientSearch,bool nonLibFlag, int systemWorkorderId, bool? isVesselSanctioned, CancellationToken ct = default)
        { 
            if (string.IsNullOrWhiteSpace(clientSearch)) return BadRequest("Search text is mandaotry");

            var vessels = await _vesselRepo.GetVessels(clientSearch,nonLibFlag,systemWorkorderId, ct);

            vessels = vessels.Where(v => !isVesselSanctioned.HasValue || v.IsVesselSanctioned == isVesselSanctioned).ToList();
            var vesselSearchList = vessels.Select(v => new VesselSearch
            {
                IMO = Convert.ToInt32(v.IMONumber),
                OfficialNumber = v.OfficialNumber,
                Name = v.Name?.ToUpper() ?? string.Empty,
                VesselId = v.VesselId,
                EntityId = v.EntityId,
                NonLibFlag = nonLibFlag,
                IsBFAEnrolled = Convert.ToBoolean(v.IsBFAEnrolled),
                IsVesselSanctioned = v.IsVesselSanctioned
            }).ToList();

            return Ok(vesselSearchList);
        }
    }
}
