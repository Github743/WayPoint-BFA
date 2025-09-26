using IdentityModel.Client;
using k8s.Models;
using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientAgreementController(ISystemDiscountRepository systemDiscountRepository, IClientAgreementRepository clientAgreementRepository) : ControllerBase
    {
        private readonly ISystemDiscountRepository _systemDiscountRepository = systemDiscountRepository;
        private readonly IClientAgreementRepository _clientAgreementRepository = clientAgreementRepository;

        [HttpGet("schedules")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountSchedules>>> GetDiscountSchedules([FromQuery] int workOrderId, int systemDiscountProgramId, CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetDiscountSchedules(workOrderId, systemDiscountProgramId, ct);
            return Ok(rows);
        }

        [HttpGet("schedule-products")]
        public async Task<ActionResult<IReadOnlyList<SystemDiscountScheduleProducts>>> GetDiscountScheduleProducts([FromQuery] int systemDiscountScheduleId, CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetDiscountScheduleProducts(systemDiscountScheduleId, ct);
            return Ok(rows);
        }

        [HttpGet("systemproducts-discountbyname")]
        public async Task<ActionResult<IReadOnlyList<SystemProductDiscountGroup>>> GetSystemProductDiscountGroupByName([FromQuery] string systemProductName, CancellationToken ct = default)
        {
            var rows = await _systemDiscountRepository.GetSystemProductDiscountGroupByName(systemProductName, ct);
            return Ok(rows);
        }

        [HttpPost("SaveEntityProducts")]
        public async Task<ActionResult<bool>> SaveEntityProducts([FromBody] List<WorkOrderClientAgreementEntityProduct> workOrderClientAgreementEntityProducts, [FromQuery] int workOrderId, int systemDiscountScheduleId, CancellationToken ct = default)
        {
            if (workOrderClientAgreementEntityProducts == null || workOrderClientAgreementEntityProducts.Count == 0
                || workOrderId == 0)
                return BadRequest("No products provided.");

            bool result = await _clientAgreementRepository.SaveEntityProducts(workOrderClientAgreementEntityProducts, workOrderId, systemDiscountScheduleId, ct);

            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, false);

            return Ok(true);
        }

        [HttpGet("GetEntityProducts")]
        public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> GetWorkOrderClientAgreementEntityProducts(int workOrderId)
        {
            var workOrderProducts = await _clientAgreementRepository.GetWorkOrderClientAgreementEntityProducts(workOrderId);
            return Ok(workOrderProducts);
        }

        [HttpGet("ClientAgreement/{workOrderId:int}")]
        public async Task<ActionResult<WorkOrderClientAgreement>> GetWorkOrderClientAgreement(int workOrderId)
        {
            var workOrderClientAgreement = await _clientAgreementRepository.GetWorkOrderClientAgreement(workOrderId);
            return Ok(workOrderClientAgreement);
        }

        [HttpGet("GetAdditionalDiscountedProducts")]
        public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> GetAdditionalDiscountedProducts(int workOrderId)
        {
            var additionalDiscountedProducts = await _clientAgreementRepository.GetAdditionalDiscountedProducts(workOrderId);
            return Ok(additionalDiscountedProducts);
        }


        [HttpPost("UpdateEntity")]
        public async Task<ActionResult<bool>> UpdateEntityProduct([FromBody] WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
        {
            bool result = await _clientAgreementRepository.UpdateEntityProduct(workOrderClientAgreementEntityProduct, ct);
            return Ok(result);
        }

        [HttpPost("RemoveEntity")]
        public async Task<ActionResult<bool>> RemoveEntityProduct([FromBody] int workOrderClientAgreementEntityProductId, CancellationToken ct = default)
        {
            bool result = await _clientAgreementRepository.RemoveEntityProduct(workOrderClientAgreementEntityProductId, ct);
            return Ok(result);
        }

        [HttpPost("RemoveEntities")]
        public async Task<ActionResult<bool>> RemoveEntityProducts([FromBody] int[] ids, CancellationToken ct = default)
        {
            if (ids == null || ids.Length == 0)
                return BadRequest("No ids supplied.");

            bool result = await _clientAgreementRepository.RemoveEntityProducts(ids, ct);
            return Ok(result);
        }

        [HttpPost("SaveProduct")]
        public async Task<ActionResult<bool>> SaveWorkOrderClientAgreementProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
        {
            bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementProduct(workOrderClientAgreementEntityProduct, ct);
            return Ok(result);
        }


    }
}
