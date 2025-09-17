using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface ISystemWorkOrderRepository
    {
        Task<SystemWorkOrder> SearchAsync(
        string systemWorkOrderName,
        CancellationToken ct = default);
    }
}
