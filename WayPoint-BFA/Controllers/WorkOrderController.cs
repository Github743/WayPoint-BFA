using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint.Model.Enhanced;
using WayPoint.Model.Helper;
//using WayPoint.Model.IHelper;
using WayPoint.Model.ViewModels;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class WorkOrderController(IWorkOrder workorder) : ControllerBase
    {
        private readonly IWorkOrder _workorder = workorder;

        [HttpGet("workorder/{workOrderId:int}")]
        public async Task<ActionResult<WorkOrder>> GetWorkOrder(int workOrderId, CancellationToken ct = default)
        {
            var workOrder = await _workorder.GetWorkOrder(workOrderId, ct);
            return Ok(workOrder);
        }

        [HttpPost("createwo")]
        public async Task<ActionResult<WorkOrder>> CreateWorkOrder(
            [FromBody] WorkOrderCreationViewModel workOrderCreationViewModel,
            CancellationToken ct = default)
        {
            try
            {
                var workorder = await _workorder.CreateWorkOrder(workOrderCreationViewModel, ct);

                if (workorder == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create work order.");

                return Ok(workorder);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpPost("searchwo")]
        public async Task<ActionResult<PagedResult<WorkOrderDetail>>> Search([FromBody] WorkOrderSearchRequest request, CancellationToken ct = default)
        {
            if (request == null) return BadRequest("Invalid request");

            var result = await _workorder.SearchAsync(request, ct);
            return Ok(result);
        }

        [HttpGet("{workOrderId}/options")]
        public async Task<ActionResult> GetOptions(int workOrderId, CancellationToken ct)
        {
            try
            {
                var options = await _workorder.GetBFAOptionsDetailsAsync(workOrderId, ct);

                if (options == null)
                    return NotFound();

                return Ok(options);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // log + return 500
                return StatusCode(500, "Unexpected error");
            }
        }

        [HttpPost("{workOrderId}/options")]
        public async Task<ActionResult> SaveOptions(int workOrderId, [FromBody] BFADetailsViewModel options,
            CancellationToken ct = default)
        {
            var result = await _workorder.SaveOptionsAsync(options, workOrderId, ct);

            if (!result)
            {
                // return 400 with message
                return BadRequest("Failed to save options. Please try again.");
            }

            return Ok(new { success = true });
        }
        [HttpGet("pendingWorkOrders")]
        public async Task<ActionResult<IReadOnlyList<WorkOrder>>> GetPendingWorkOrders([FromQuery] int? systemWorkorderId, int? ClientId = null, CancellationToken ct = default)
        {
            var rows = await _workorder.GetPendingWorkOrdersbyContext(ClientId, systemWorkorderId, true, ct);
            return Ok(rows);
        }
        //[HttpPost("workOrderPreValidation")]
        //public async Task<ActionResult<IReadOnlyList<WorkOrder>>> WorkOrderPreValidation([FromBody] WorkOrderCreationViewModel workOrderCreationViewModel, CancellationToken ct = default)
        //{
        //    workOrderCreationViewModel.SystemWorkOrderId = 1146;
        //    var rows = await _workorder.GetSystemWorkOrderUserPermissions(workOrderCreationViewModel.SystemWorkOrderId, ct);
        //    return Ok(rows);
        //}
        [HttpGet("workorderPrevalidations")]
        public async Task<string> IsWorkOrderEligible(WorkOrderCreationViewModel creationData)
        {
            string valMsg = await _workorder.IsWorkOrderEligible(creationData);
            return "";
        }
    }
}
