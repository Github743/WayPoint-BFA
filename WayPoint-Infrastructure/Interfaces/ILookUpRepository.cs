using WayPoint.Model;
using WayPoint.Model.Helper;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface ILookUpRepository
    {
        Task<IReadOnlyList<Lookup>> GetLookupsByTypeName(string lookupTypebyName,
       CancellationToken ct = default);
        Task<Lookup> GetLookupByTypeName(string lookupName, LookupTypeName lookupTypeName,
       CancellationToken ct = default);
    }
}
