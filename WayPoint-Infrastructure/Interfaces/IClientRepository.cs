using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IReadOnlyList<ClientDetail>> GetClientsAsync(string clientSearch, CancellationToken ct = default);
        Task<Client> GetClient(int clientId, CancellationToken ct = default);
    }
}
