using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface ISystemDiscountRepository
    {
        Task<IReadOnlyList<SystemDiscountSchedules>> GetDiscountSchedules(
        int workOrderId,
        int systemDiscountProgramId,
        CancellationToken ct = default);

        Task<IReadOnlyList<SystemDiscountScheduleProducts>> GetDiscountScheduleProducts(
        int systemDiscountScheduleId,
        CancellationToken ct = default);

        Task<IReadOnlyList<SystemProductDiscountGroup>> GetSystemProductDiscountGroupByName(
        string systemProductName,
        CancellationToken ct = default);
    }
}
