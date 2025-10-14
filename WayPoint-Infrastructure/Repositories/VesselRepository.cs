using System.Collections.ObjectModel;
using WayPoint.Model;
using WayPoint.Model.Helper;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    internal class VesselRepository(ISqlEngine sql,ILookUpRepository lookupRepo) :IVesselRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        private readonly ILookUpRepository _lookupRepo = lookupRepo;
        public async Task<IReadOnlyList<Vessel>> GetVessels(string clientSearch, CancellationToken ct = default)
        {

            Lookup lookupFlagState = await _lookupRepo.GetLookupByTypeName(ApplicationConstants.FLAGSTATE_LIBERIA, LookupTypeName.FlagState ,ct);
            var queryable = await _sql.RetrieveObjectsAsync<Vessel>(
                new { SearchParam = clientSearch },
                ct
            );

            var list = queryable.ToList();

            return new ReadOnlyCollection<Vessel>(list);
        }
    }
}
