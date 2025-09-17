using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class LookUpController(ILookUpRepository lookUpRepository) : ControllerBase
    {
        private readonly ILookUpRepository _lookUpRepository = lookUpRepository;
        [HttpGet("getLookupTypeByName")]
        public async Task<ActionResult<IReadOnlyList<Lookup>>> GetLookupTypeByName([FromQuery] string LookupTypeName, CancellationToken ct = default)
        {
            var rows = await _lookUpRepository.GetLookupsByTypeName(LookupTypeName, ct);
            var lookups = rows.Where(e => e.CanShow);
            if (LookupTypeName != ApplicationConstants.LOOKUPTYPE_LOCAL_TIME_ZONE)
                lookups = lookups.OrderBy(s => s.DisplayName).ToList();
            else
                lookups = lookups.OrderBy(s => s.LookupId).ToList();
            return Ok(lookups);
        }
        [HttpGet("getetLookupsByLookupTypeName")]
        public async Task<ActionResult<IReadOnlyList<Lookup>>> GetLookupsByLookupTypeName([FromQuery] string LookupTypeName, CancellationToken ct = default)
        {
            var rows = await _lookUpRepository.GetLookupsByTypeName(LookupTypeName, ct);
            return Ok(rows);
        }
    }
}
