using BFAWebApp.Domain.ReadModels;

namespace BFAWebApp.Domain.Interfaces
{
    public interface ISystemDiscountRepository
    {
        Task<IReadOnlyList<SystemDiscountSchedule>> GetDiscountSchedulesAsync(
        int workOrderId,
        int systemDiscountProgramId,
        CancellationToken ct = default);
    }
}
