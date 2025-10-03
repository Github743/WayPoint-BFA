using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class WorkOrderInvoiceController(IWorkOrderInvoiceRepository workOrderInvoice) : ControllerBase
    {
        private readonly IWorkOrderInvoiceRepository _workOrderInvoice = workOrderInvoice;
        
        [HttpGet("woInvoiceItems")]
        public async Task<ActionResult<IReadOnlyList<WorkOrderInvoiceItem>>> GetWorkOrderInvoiceLineItems([FromQuery] int workOrderInvoiceId, CancellationToken ct = default)
        {
            var invoiceItems = await _workOrderInvoice.GetWorkOrderInvoiceLineItems(workOrderInvoiceId, ct);
            return Ok(invoiceItems);
        }

        [HttpGet("fleetInvoices")]
        public async Task<ActionResult<IReadOnlyList<WorkOrderInvoice>>> GetFleetWorkOrderInvoice([FromQuery] int workOrderId, CancellationToken ct = default)
        {
            var invoices = await _workOrderInvoice.GetFleetWorkOrderInvoice(workOrderId, ct);
            return Ok(invoices);
        }
    }
}
