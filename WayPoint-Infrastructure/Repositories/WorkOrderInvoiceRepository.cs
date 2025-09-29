using System.Collections.ObjectModel;
using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class WorkOrderInvoiceRepository(ISqlEngine sql) : IWorkOrderInvoiceRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        public async Task<IReadOnlyList<WorkOrderInvoiceItem>> GetWorkOrderInvoiceLineItems(int workOrderInvoiceId, CancellationToken ct = default)
        {
            var queryable = await _sql.RetrieveObjectsAsync<WorkOrderInvoiceItem>(
                new { WorkOrderInvoiceId = workOrderInvoiceId },
                ct
            );

            var list = queryable.ToList();

            return new ReadOnlyCollection<WorkOrderInvoiceItem>(list);
        }

        public async Task<IReadOnlyList<WorkOrderInvoice>> GetFleetWorkOrderInvoice(int workOrderId, CancellationToken ct = default)
        {
            var queryable = await _sql.RetrieveObjectsAsync<WorkOrderInvoice>(
                new { WorkOrderId = workOrderId },
                ct
            );

            var list = queryable.ToList();

            return new ReadOnlyCollection<WorkOrderInvoice>(list);
        }
    }
}
