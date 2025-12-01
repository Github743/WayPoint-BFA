using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint.Model.Common;

//using WayPoint.Model.IHelper;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderRepository _workorder;
        private readonly ILogger<WorkOrderController> _logger;

        public WorkOrderController(IWorkOrderRepository workorder, ILogger<WorkOrderController> logger)
        {
            _workorder = workorder ?? throw new ArgumentNullException(nameof(workorder));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("workorder/{workOrderId:int}")]
        //public async Task<ActionResult<WorkOrder>> GetWorkOrder(int workOrderId, CancellationToken ct = default)
        public async Task<ActionResult<ApiResponseDTO<WorkOrder>>> GetWorkOrder(int workOrderId, CancellationToken ct = default)
        {
            //var workOrder = await _workorder.GetWorkOrder(workOrderId, ct);
            //return Ok(workOrder);

            _logger.LogInformation("GetWorkOrder called. WorkOrderId={WorkOrderId}", workOrderId);

            if (workOrderId <= 0)
            {
                _logger.LogWarning("GetWorkOrder validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
                return BadRequest(ApiResponseDTO<string>.Fail("Invalid work order id."));
            }

            try
            {
                var workOrder = await _workorder.GetWorkOrder(workOrderId, ct);

                if (workOrder == null)
                {
                    _logger.LogInformation("WorkOrder not found. WorkOrderId={WorkOrderId}", workOrderId);
                    return NotFound(ApiResponseDTO<string>.Fail("Work order not found."));
                }

                return Ok(ApiResponseDTO<WorkOrder>.Ok(workOrder));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "GetWorkOrder request cancelled. WorkOrderId={WorkOrderId}", workOrderId);
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Error fetching work order (WorkOrderId={workOrderId}) due to {ex.Message}"));

            }
        }

        [HttpPost("createwo")]
        //public async Task<ActionResult<WorkOrder>> CreateWorkOrder(
        //    [FromBody] WorkOrderCreationViewModel workOrderCreationViewModel,
        //    CancellationToken ct = default)
        public async Task<ActionResult<ApiResponseDTO<WorkOrder>>> CreateWorkOrder(
            [FromBody] WorkOrderCreationViewModel workOrderCreationViewModel,
            CancellationToken ct = default)
        {
            //try
            //{
            //    var workorder = await _workorder.CreateWorkOrder(workOrderCreationViewModel, ct);

            //    if (workorder == null)
            //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create work order.");

            //    return Ok(workorder);
            //}
            //catch (OperationCanceledException)
            //{
            //    return StatusCode(StatusCodes.Status499ClientClosedRequest);
            //}
            //catch (ArgumentException aex)
            //{
            //    return BadRequest(aex.Message);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            //}

            _logger.LogInformation("CreateWorkOrder called.");

            if (workOrderCreationViewModel == null)
            {
                _logger.LogWarning("CreateWorkOrder validation failed: body is null.");
                return BadRequest(ApiResponseDTO<string>.Fail("Request body is required."));
            }

            try
            {
                var workorder = await _workorder.CreateWorkOrder(workOrderCreationViewModel, ct);

                if (workorder == null)
                {
                    _logger.LogError("CreateWorkOrder failed: repository returned null.");
                    return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to create work order."));
                }

                _logger.LogInformation("CreateWorkOrder succeeded. WorkOrderId={WorkOrderId}", workorder.WorkOrderId);

                return Ok(ApiResponseDTO<WorkOrder>.Ok(workorder));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "CreateWorkOrder request cancelled.");
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (ArgumentException aex)
            {
                _logger.LogWarning(aex, "CreateWorkOrder validation/argument error.");
                return BadRequest(ApiResponseDTO<string>.Fail(aex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Unexpected error while creating work order  due to {ex.Message}"));
            }
        }

        [HttpPost("searchwo")]
        //public async Task<ActionResult<PagedResult<WorkOrderDetail>>> Search([FromBody] WorkOrderSearchRequest request, CancellationToken ct = default)
        public async Task<ActionResult<ApiResponseDTO<PagedResult<WorkOrderDetail>>>> Search([FromBody] WorkOrderSearchRequest request, CancellationToken ct = default)
        {
            //if (request == null) return BadRequest("Invalid request");

            //var result = await _workorder.SearchAsync(request, ct);
            //return Ok(result);

            _logger.LogInformation("Search called.");

            if (request == null)
            {
                _logger.LogWarning("Search validation failed: request is null.");
                return BadRequest(ApiResponseDTO<string>.Fail("Invalid request."));
            }

            try
            {
                var result = await _workorder.SearchAsync(request, ct);
                return Ok(ApiResponseDTO<PagedResult<WorkOrderDetail>>.Ok(result));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "Search request cancelled.");
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while searching work orders due to {ex.Message}"));
            }
        }

        [HttpGet("{workOrderId}/options")]
        // public async Task<ActionResult> GetOptions(int workOrderId, CancellationToken ct)
        public async Task<ActionResult<ApiResponseDTO<BFADetailsViewModel>>> GetOptions(int workOrderId, CancellationToken ct = default)
        {
            _logger.LogInformation("GetOptions called. WorkOrderId={WorkOrderId}", workOrderId);

            if (workOrderId <= 0)
            {
                _logger.LogWarning("GetOptions validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
                return BadRequest(ApiResponseDTO<string>.Fail("Invalid work order id."));
            }

            try
            {
                var options = await _workorder.GetBFAOptionsDetailsAsync(workOrderId, ct);

                if (options == null)
                {
                    _logger.LogInformation("GetOptions: not found. WorkOrderId={WorkOrderId}", workOrderId);
                    return NotFound(ApiResponseDTO<string>.Fail("Options not found."));
                }

                return Ok(ApiResponseDTO<BFADetailsViewModel>.Ok(options));
            }
            catch (ArgumentException aex)
            {
                _logger.LogWarning(aex, "GetOptions argument error.");
                return BadRequest(ApiResponseDTO<string>.Fail(aex.Message));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "GetOptions request cancelled. WorkOrderId={WorkOrderId}", workOrderId);
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Unexpected error fetching options for WorkOrderId={workOrderId} due to {ex.Message}"));
            }
        }

        [HttpPost("{workOrderId}/options")]
        //public async Task<ActionResult> SaveOptions(int workOrderId, [FromBody] BFADetailsViewModel options,
        //    CancellationToken ct = default)
        public async Task<ActionResult<ApiResponseDTO<object>>> SaveOptions(int workOrderId, [FromBody] BFADetailsViewModel options, CancellationToken ct = default)
        {
            //var result = await _workorder.SaveOptionsAsync(options, workOrderId, ct);

            //if (!result)
            //{
            //    // return 400 with message
            //    return BadRequest("Failed to save options. Please try again.");
            //}

            //return Ok(new { success = true });

            _logger.LogInformation("SaveOptions called. WorkOrderId={WorkOrderId}", workOrderId);

            if (workOrderId <= 0 || options == null)
            {
                _logger.LogWarning("SaveOptions validation failed. WorkOrderId={WorkOrderId}, OptionsNull={OptionsNull}", workOrderId, options == null);
                return BadRequest(ApiResponseDTO<string>.Fail("Invalid request."));
            }

            try
            {
                var result = await _workorder.SaveOptionsAsync(options, workOrderId, ct);

                if (!result)
                {
                    _logger.LogWarning("SaveOptions failed for WorkOrderId={WorkOrderId}", workOrderId);
                    return BadRequest(ApiResponseDTO<string>.Fail("Failed to save options. Please try again."));
                }

                return Ok(ApiResponseDTO<object>.Ok(new { success = true }));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "SaveOptions request cancelled. WorkOrderId={WorkOrderId}", workOrderId);
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Unexpected error saving options for WorkOrderId={workOrderId} due to {ex.Message}"));
            }
        }
        [HttpGet("pendingWorkOrders")]
        // public async Task<ActionResult<IReadOnlyList<WorkOrder>>> GetPendingWorkOrders([FromQuery] int? systemWorkorderId, int? ClientId = null, CancellationToken ct = default)
        public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<WorkOrder>>>> GetPendingWorkOrders([FromQuery] int? systemWorkorderId, int? ClientId = null, CancellationToken ct = default)
        {
            //var rows = await _workorder.GetPendingWorkOrdersbyContext(ClientId, systemWorkorderId, true, ct);
            //return Ok(rows);

            _logger.LogInformation("GetPendingWorkOrders called. SystemWorkorderId={SystemWorkorderId}, ClientId={ClientId}", systemWorkorderId, ClientId);

            try
            {
                var rows = await _workorder.GetPendingWorkOrdersbyContext(ClientId, systemWorkorderId, true, ct);
                return Ok(ApiResponseDTO<IReadOnlyList<WorkOrder>>.Ok(rows));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "GetPendingWorkOrders request cancelled.");
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Error fetching pending work orders due to {ex.Message}"));
            }
        }
        //[HttpPost("workOrderPreValidation")]
        //public async Task<ActionResult<IReadOnlyList<WorkOrder>>> WorkOrderPreValidation([FromBody] WorkOrderCreationViewModel workOrderCreationViewModel, CancellationToken ct = default)
        //{
        //    workOrderCreationViewModel.SystemWorkOrderId = 1146;
        //    var rows = await _workorder.GetSystemWorkOrderUserPermissions(workOrderCreationViewModel.SystemWorkOrderId, ct);
        //    return Ok(rows);
        //}
        [HttpPost("workorderPrevalidations")]
        // public async Task<string> IsWorkOrderEligible(WorkOrderCreationViewModel creationData)
        public async Task<ActionResult<ApiResponseDTO<string>>> IsWorkOrderEligible([FromBody] WorkOrderCreationViewModel creationData, CancellationToken ct = default)
        {
            // return await _workorder.IsWorkOrderEligible(creationData);

            _logger.LogInformation("IsWorkOrderEligible called.");

            if (creationData == null)
            {
                _logger.LogWarning("IsWorkOrderEligible validation failed: creationData is null.");
                return BadRequest(ApiResponseDTO<string>.Fail("Invalid request body."));
            }

            try
            {
                var result = await _workorder.IsWorkOrderEligible(creationData);
                return Ok(ApiResponseDTO<string>.Ok(result));
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogWarning(oce, "IsWorkOrderEligible request cancelled.");
                return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while validating work order eligibility due to {ex.Message}"));
            }
        }

    }
}
