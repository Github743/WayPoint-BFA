using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface IWorkOrderInvoiceRepository
    {
        Task<IReadOnlyList<WorkOrderInvoiceItem>> GetWorkOrderInvoiceLineItems(int workOrderInvoiceId, CancellationToken ct = default);
        Task<IReadOnlyList<WorkOrderInvoice>> GetFleetWorkOrderInvoice(int workOrderId, CancellationToken ct = default);
    }
}
