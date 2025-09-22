using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class LookUpRepository : ILookUpRepository
    {
        private readonly ISqlEngine _sql;

        public LookUpRepository(ISqlEngine sql)
        {
            _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        }
        public async Task<IReadOnlyList<Lookup>> GetLookupsByTypeName(string lookupTypebyName, CancellationToken ct = default)
        {
            {
                var empty = Array.Empty<Lookup>();
                var lookups = await _sql.RetrieveObjectsAsync<Lookup>(
                    new { LookupTypeName = lookupTypebyName },
                    ct);

                if (lookups == null)
                    return empty;
                return lookups ?? empty;
            }
        }
    }
}
