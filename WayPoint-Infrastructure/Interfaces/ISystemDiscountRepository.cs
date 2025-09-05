using WayPoint_Models;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface ISystemDiscountRepository
    {
        Task<IReadOnlyList<SystemDiscountScheduleDto>> GetDiscountSchedulesAsync(
        int workOrderId,
        int systemDiscountProgramId,
        CancellationToken ct = default);
    }
}
