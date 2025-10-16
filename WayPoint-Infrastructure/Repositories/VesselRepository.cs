using System.Collections.ObjectModel;
using WayPoint.Model;
using WayPoint.Model.Helper;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class VesselRepository(ISqlEngine sql,ILookUpRepository lookupRepo) :IVesselRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        private readonly ILookUpRepository _lookupRepo = lookupRepo;
        public async Task<IReadOnlyList<Vessel>> GetVessels(string searchText, bool nonLibFlag, int systemWorkorderId, CancellationToken ct = default)
        {
            Lookup lookupFlagState = await _lookupRepo.GetLookupByTypeName(ApplicationConstants.FLAGSTATE_LIBERIA, LookupTypeName.FlagState ,ct);

            var vessels = await _sql.RetrieveObjectsAsync<Vessel>(new { VesselLookup = searchText },ct);
            vessels = nonLibFlag ? vessels :
                             vessels.Where(m =>
                                 (m.StatusName == ApplicationConstants.LOOKUPTYPE_VESSEL_STATUS_ACTIVE) ||
                                 (m.StatusName == ApplicationConstants.LOOKUPTYPE_VESSEL_STATUS_LAIDUP) ||
                                 (m.StatusName == ApplicationConstants.LOOKUPTYPE_VESSEL_STATUS_PENDING)).ToList();
            vessels = !nonLibFlag ? vessels.Where(m => m.FlagState == lookupFlagState.LookupId).ToList() :
                                                   vessels.Where(m => m.FlagState != lookupFlagState.LookupId).ToList();

            string vesselIdList = string.Join(",", vessels.Select(e => e.VesselId));

            List<VesselClient> vClient =(await _sql.RetrieveObjectsAsync<VesselClient>( new { VesselIdList= vesselIdList },ct)).Where(e => e.ClientTypeName.ToLower() == "bfa" && e.ToDate == null).ToList();
            vessels = vessels.LeftJoin(vClient,
                                                     l => l.VesselId,
                                                     r => r.VesselId,
                                                     (l, r) => new Vessel
                                                     {
                                                         VesselId = l.VesselId,
                                                         Name = l.Name,
                                                         IMONumber = l.IMONumber,
                                                         OfficialNumber = l.OfficialNumber,
                                                         EntityId = l.EntityId,
                                                         IsBFAEnrolled = (r != null ? true : false),
                                                         IsVesselSanctioned = l.IsVesselSanctioned
                                                     }).ToList();

            var list = vessels.ToList();

            return new ReadOnlyCollection<Vessel>(list);
        }
    }
}
