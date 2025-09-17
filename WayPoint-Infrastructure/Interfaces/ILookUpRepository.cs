using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface ILookUpRepository
    {
        Task<IReadOnlyList<Lookup>> GetLookupsByTypeName(string lookupTypebyName,
       CancellationToken ct = default);
    }
}
