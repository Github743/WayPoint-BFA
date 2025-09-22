using System.Collections.ObjectModel;
using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class ClientRepository(ISqlEngine sql) : IClientRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));

        public async Task<IReadOnlyList<ClientDetail>> GetClientsAsync(
            string clientSearch, CancellationToken ct = default)
        {            
            var queryable = await _sql.RetrieveObjectsAsync<ClientDetail>(
                new { SearchParam = clientSearch },
                ct
            );

            var list = queryable.ToList();

            return new ReadOnlyCollection<ClientDetail>(list);
        }

        public async Task<Client> GetClient(int clientId, CancellationToken ct = default)
        {
            return await _sql.RetrieveObjectAsync<Client>(new { clientId }, ct);
        }
    }
}
