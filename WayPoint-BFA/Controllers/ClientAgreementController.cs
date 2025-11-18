using IdentityModel.Client;
using IdentityModel.OidcClient;
using k8s.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WayPoint.Model;
using WayPoint.Model.Common;
using WayPoint.Model.ViewModels;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientAgreementController : ControllerBase
    {

		private readonly ISystemDiscountRepository _systemDiscountRepository;
		private readonly IClientAgreementRepository _clientAgreementRepository;
		private readonly ILogger<ClientAgreementController> _logger;

		public ClientAgreementController(
			ISystemDiscountRepository systemDiscountRepository,
			IClientAgreementRepository clientAgreementRepository,
			ILogger<ClientAgreementController> logger)
		{
			_systemDiscountRepository = systemDiscountRepository;
			_clientAgreementRepository = clientAgreementRepository;
			_logger = logger;
		}
		
        [HttpGet("schedules")]
		// public async Task<ActionResult<IReadOnlyList<SystemDiscountSchedules>>> GetDiscountSchedules([FromQuery] int workOrderId, int systemDiscountProgramId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<SystemDiscountSchedules>>>> GetDiscountSchedules([FromQuery] int workOrderId, [FromQuery] int systemDiscountProgramId, CancellationToken ct = default)
		{
			//var rows = await _systemDiscountRepository.GetDiscountSchedules(workOrderId, systemDiscountProgramId, ct);
			//return Ok(rows);
			_logger.LogInformation("GetDiscountSchedules called. WorkOrderId={WorkOrderId}, SystemDiscountProgramId={SystemDiscountProgramId}", workOrderId, systemDiscountProgramId);

			if (workOrderId <= 0)
			{
				_logger.LogWarning("GetDiscountSchedules validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid workOrderId."));
			}

			try
			{
				var rows = await _systemDiscountRepository.GetDiscountSchedules(workOrderId, systemDiscountProgramId, ct);
				_logger.LogInformation("GetDiscountSchedules succeeded. ReturnedCount={Count}", rows?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<SystemDiscountSchedules>>.Ok(rows));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetDiscountSchedules request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching discount schedules for WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching discount schedules due to {ex.Message}"));
			}
		}

        [HttpGet("schedule-products")]
		// public async Task<ActionResult<IReadOnlyList<SystemDiscountScheduleProducts>>> GetDiscountScheduleProducts([FromQuery] int systemDiscountScheduleId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<SystemDiscountScheduleProducts>>>> GetDiscountScheduleProducts([FromQuery] int systemDiscountScheduleId, CancellationToken ct = default)
		{
			//var rows = await _systemDiscountRepository.GetDiscountScheduleProducts(systemDiscountScheduleId, ct);
			//return Ok(rows);

			_logger.LogInformation("GetDiscountScheduleProducts called. SystemDiscountScheduleId={Id}", systemDiscountScheduleId);

			if (systemDiscountScheduleId <= 0)
			{
				_logger.LogWarning("GetDiscountScheduleProducts validation failed: invalid id {Id}", systemDiscountScheduleId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid systemDiscountScheduleId."));
			}

			try
			{
				var rows = await _systemDiscountRepository.GetDiscountScheduleProducts(systemDiscountScheduleId, ct);
				_logger.LogInformation("GetDiscountScheduleProducts succeeded. ReturnedCount={Count}", rows?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<SystemDiscountScheduleProducts>>.Ok(rows));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetDiscountScheduleProducts request was canceled. Id={Id}", systemDiscountScheduleId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching schedule products for Id={Id}", systemDiscountScheduleId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching schedule products due to {ex.Message}"));
			}
		}

        [HttpGet("systemproducts-discountbyname")]
		// public async Task<ActionResult<IReadOnlyList<SystemProductDiscountGroup>>> GetSystemProductDiscountGroupByName([FromQuery] string systemProductName, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<SystemProductDiscountGroup>>>> GetSystemProductDiscountGroupByName([FromQuery] string systemProductName, CancellationToken ct = default)
		{
			//var rows = await _systemDiscountRepository.GetSystemProductDiscountGroupByName(systemProductName, ct);
			//return Ok(rows);

			_logger.LogInformation("GetSystemProductDiscountGroupByName called. Name='{Name}'", systemProductName);

			if (string.IsNullOrWhiteSpace(systemProductName))
			{
				_logger.LogWarning("GetSystemProductDiscountGroupByName validation failed: name empty.");
				return BadRequest(ApiResponseDTO<string>.Fail("systemProductName is mandatory."));
			}

			try
			{
				var rows = await _systemDiscountRepository.GetSystemProductDiscountGroupByName(systemProductName, ct);
				_logger.LogInformation("GetSystemProductDiscountGroupByName succeeded. ReturnedCount={Count}", rows?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<SystemProductDiscountGroup>>.Ok(rows));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetSystemProductDiscountGroupByName request was canceled. Name='{Name}'", systemProductName);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching product discount groups for Name='{Name}'", systemProductName);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching product discount groups due to {ex.Message}"));
			}
		}

        [HttpPost("SaveEntityProducts")]
		// public async Task<ActionResult<bool>> SaveEntityProducts([FromBody] List<WorkOrderClientAgreementEntityProduct> workOrderClientAgreementEntityProducts, [FromQuery] int workOrderId, int systemDiscountScheduleId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> SaveEntityProducts([FromBody] List<WorkOrderClientAgreementEntityProduct> workOrderClientAgreementEntityProducts, [FromQuery] int workOrderId, [FromQuery] int systemDiscountScheduleId, CancellationToken ct = default)
		{
			//if (workOrderClientAgreementEntityProducts == null || workOrderClientAgreementEntityProducts.Count == 0
			//    || workOrderId == 0)
			//    return BadRequest("No products provided.");

			//bool result = await _clientAgreementRepository.SaveEntityProducts(workOrderClientAgreementEntityProducts, workOrderId, systemDiscountScheduleId, ct);

			//if (!result)
			//    return StatusCode(StatusCodes.Status500InternalServerError, false);

			//return Ok(true);

			_logger.LogInformation("SaveEntityProducts called. WorkOrderId={WorkOrderId}, SystemDiscountScheduleId={ScheduleId}, Count={Count}",
				workOrderId, systemDiscountScheduleId, workOrderClientAgreementEntityProducts?.Count ?? 0);

			if (workOrderClientAgreementEntityProducts == null || workOrderClientAgreementEntityProducts.Count == 0 || workOrderId <= 0)
			{
				_logger.LogWarning("SaveEntityProducts validation failed.");
				return BadRequest(ApiResponseDTO<string>.Fail("No products provided or invalid workOrderId."));
			}

			try
			{
				bool result = await _clientAgreementRepository.SaveEntityProducts(workOrderClientAgreementEntityProducts, workOrderId, systemDiscountScheduleId, ct);
				if (!result)
				{
					_logger.LogWarning("SaveEntityProducts failed to persist products. WorkOrderId={WorkOrderId}", workOrderId);
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to save entity products."));
				}

				_logger.LogInformation("SaveEntityProducts succeeded. WorkOrderId={WorkOrderId}", workOrderId);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveEntityProducts request was canceled. WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving entity products for WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving entity products due to {ex.Message}"));
			}
		}

        [HttpGet("GetEntityProducts")]
		// public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> GetWorkOrderClientAgreementEntityProducts(int workOrderId)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>>> GetWorkOrderClientAgreementEntityProducts([FromQuery] int workOrderId, CancellationToken ct = default)
		{
			//var workOrderProducts = await _clientAgreementRepository.GetWorkOrderClientAgreementEntityProducts(workOrderId);
			//return Ok(workOrderProducts);

			_logger.LogInformation("GetWorkOrderClientAgreementEntityProducts called. WorkOrderId={WorkOrderId}", workOrderId);

			if (workOrderId <= 0)
			{
				_logger.LogWarning("GetWorkOrderClientAgreementEntityProducts validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid workOrderId."));
			}

			try
			{
				var workOrderProducts = await _clientAgreementRepository.GetWorkOrderClientAgreementEntityProducts(workOrderId);
				_logger.LogInformation("GetWorkOrderClientAgreementEntityProducts succeeded. ReturnedCount={Count}", workOrderProducts?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>.Ok(workOrderProducts));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetWorkOrderClientAgreementEntityProducts request was canceled. WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching entity products for WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching entity products due to {ex.Message}"));
			}
		}

        [HttpGet("ClientAgreement/{workOrderId:int}")]
		//  public async Task<ActionResult<WorkOrderClientAgreement>> GetWorkOrderClientAgreement(int workOrderId)
		public async Task<ActionResult<ApiResponseDTO<WorkOrderClientAgreement>>> GetWorkOrderClientAgreement([FromRoute] int workOrderId, CancellationToken ct = default)
		{
			//var workOrderClientAgreement = await _clientAgreementRepository.GetWorkOrderClientAgreement(workOrderId);
			//return Ok(workOrderClientAgreement);

			_logger.LogInformation("GetWorkOrderClientAgreement called. WorkOrderId={WorkOrderId}", workOrderId);

			if (workOrderId <= 0)
			{
				_logger.LogWarning("GetWorkOrderClientAgreement validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid workOrderId."));
			}

			try
			{
				var agreement = await _clientAgreementRepository.GetWorkOrderClientAgreement(workOrderId);
				if (agreement == null)
				{
					_logger.LogInformation("GetWorkOrderClientAgreement: not found. WorkOrderId={WorkOrderId}", workOrderId);
					return NotFound(ApiResponseDTO<string>.Fail("Work order client agreement not found."));
				}

				_logger.LogInformation("GetWorkOrderClientAgreement succeeded. WorkOrderId={WorkOrderId}", workOrderId);
				return Ok(ApiResponseDTO<WorkOrderClientAgreement>.Ok(agreement));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetWorkOrderClientAgreement request was canceled. WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching work order client agreement for WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching client agreement due to {ex.Message}"));
			}
		}

        [HttpGet("AdditionalDiscountedProducts")]
		// public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> GetAdditionalDiscountedProducts(int workOrderId)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>>> GetAdditionalDiscountedProducts([FromQuery] int workOrderId, CancellationToken ct = default)
		{
			//var additionalDiscountedProducts = await _clientAgreementRepository.GetAdditionalDiscountedProducts(workOrderId);
			//return Ok(additionalDiscountedProducts);

			_logger.LogInformation("GetAdditionalDiscountedProducts called. WorkOrderId={WorkOrderId}", workOrderId);

			if (workOrderId <= 0)
			{
				_logger.LogWarning("GetAdditionalDiscountedProducts validation failed: invalid WorkOrderId={WorkOrderId}", workOrderId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid workOrderId."));
			}

			try
			{
				var additional = await _clientAgreementRepository.GetAdditionalDiscountedProducts(workOrderId);
				_logger.LogInformation("GetAdditionalDiscountedProducts succeeded. ReturnedCount={Count}", additional?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>.Ok(additional));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetAdditionalDiscountedProducts request was canceled. WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching additional discounted products for WorkOrderId={WorkOrderId}", workOrderId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching additional discounted products due to {ex.Message}"));
			}
		}
        [HttpGet("WorkOrderClientAgreementEntities")]
		// public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> GetWorkOrderClientAgreementEntities(int workOrderClientAgreementId, int clientId)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntity>>>> GetWorkOrderClientAgreementEntities([FromQuery] int workOrderClientAgreementId, [FromQuery] int clientId, CancellationToken ct = default)
		{
			//var additionalDiscountedProducts = await _systemDiscountRepository.GetWorkOrderClientAgreementEntities(workOrderClientAgreementId, clientId);
			//return Ok(additionalDiscountedProducts);

			_logger.LogInformation("GetWorkOrderClientAgreementEntities called. AgreementId={AgreementId}, ClientId={ClientId}", workOrderClientAgreementId, clientId);

			if (workOrderClientAgreementId <= 0 || clientId <= 0)
			{
				_logger.LogWarning("GetWorkOrderClientAgreementEntities validation failed. AgreementId={AgreementId}, ClientId={ClientId}", workOrderClientAgreementId, clientId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid workOrderClientAgreementId or clientId."));
			}

			try
			{
				var entities = await _systemDiscountRepository.GetWorkOrderClientAgreementEntities(workOrderClientAgreementId, clientId);
				_logger.LogInformation("GetWorkOrderClientAgreementEntities succeeded. ReturnedCount={Count}", entities?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntity>>.Ok(entities));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetWorkOrderClientAgreementEntities request was canceled. AgreementId={AgreementId}", workOrderClientAgreementId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while fetching work order client agreement entities for AgreementId={AgreementId}, ClientId={ClientId}", workOrderClientAgreementId, clientId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching entities due to {ex.Message}"));
			}
		}
        [HttpPost("UpdateEntity")]
		// public async Task<ActionResult<bool>> UpdateEntityProduct([FromBody] WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> UpdateEntityProduct([FromBody] WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
		{
			//bool result = await _clientAgreementRepository.UpdateEntityProduct(workOrderClientAgreementEntityProduct, ct);
			//return Ok(result);
			_logger.LogInformation("UpdateEntityProduct called. EntityProductId={Id}", workOrderClientAgreementEntityProduct?.WorkOrderClientAgreementEntityProductId ?? 0);

			if (workOrderClientAgreementEntityProduct == null)
			{
				_logger.LogWarning("UpdateEntityProduct validation failed: null payload.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid payload."));
			}

			try
			{
				bool result = await _clientAgreementRepository.UpdateEntityProduct(workOrderClientAgreementEntityProduct, ct);
				if (!result)
				{
					_logger.LogWarning("UpdateEntityProduct failed for EntityProductId={Id}", workOrderClientAgreementEntityProduct.WorkOrderClientAgreementEntityProductId);
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to update entity product."));
				}

				_logger.LogInformation("UpdateEntityProduct succeeded for EntityProductId={Id}", workOrderClientAgreementEntityProduct.WorkOrderClientAgreementEntityProductId);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "UpdateEntityProduct request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while updating entity product Id={Id}", workOrderClientAgreementEntityProduct?.WorkOrderClientAgreementEntityProductId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while updating entity product due to {ex.Message}"));
			}
		}

        [HttpPost("RemoveEntity")]
		//public async Task<ActionResult<bool>> RemoveEntityProduct([FromBody] int workOrderClientAgreementEntityProductId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> RemoveEntityProduct([FromBody] int workOrderClientAgreementEntityProductId, CancellationToken ct = default)
		{
			//bool result = await _clientAgreementRepository.RemoveEntityProduct(workOrderClientAgreementEntityProductId, ct);
			//return Ok(result);

			_logger.LogInformation("RemoveEntityProduct called. Id={Id}", workOrderClientAgreementEntityProductId);

			if (workOrderClientAgreementEntityProductId <= 0)
			{
				_logger.LogWarning("RemoveEntityProduct validation failed: invalid id {Id}", workOrderClientAgreementEntityProductId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid id."));
			}

			try
			{
				bool result = await _clientAgreementRepository.RemoveEntityProduct(workOrderClientAgreementEntityProductId, ct);
				if (!result)
				{
					_logger.LogWarning("RemoveEntityProduct failed for Id={Id}", workOrderClientAgreementEntityProductId);
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to remove entity product."));
				}

				_logger.LogInformation("RemoveEntityProduct succeeded for Id={Id}", workOrderClientAgreementEntityProductId);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "RemoveEntityProduct request was canceled. Id={Id}", workOrderClientAgreementEntityProductId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while removing entity product Id={Id}", workOrderClientAgreementEntityProductId);
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while removing entity product due to {ex.Message}"));
			}
		}

        [HttpPost("RemoveEntities")]
		// public async Task<ActionResult<bool>> RemoveEntityProducts([FromBody] int[] ids, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> RemoveEntityProducts([FromBody] int[] ids, CancellationToken ct = default)
		{
			//if (ids == null || ids.Length == 0)
			//    return BadRequest("No ids supplied.");

			//bool result = await _clientAgreementRepository.RemoveEntityProducts(ids, ct);
			//return Ok(result);

			_logger.LogInformation("RemoveEntityProducts called. Count={Count}", ids?.Length ?? 0);

			if (ids == null || ids.Length == 0)
			{
				_logger.LogWarning("RemoveEntityProducts validation failed: no ids supplied.");
				return BadRequest(ApiResponseDTO<string>.Fail("No ids supplied."));
			}

			try
			{
				bool result = await _clientAgreementRepository.RemoveEntityProducts(ids, ct);
				if (!result)
				{
					_logger.LogWarning("RemoveEntityProducts failed. Count={Count}", ids.Length);
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to remove entities."));
				}

				_logger.LogInformation("RemoveEntityProducts succeeded. Count={Count}", ids.Length);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "RemoveEntityProducts request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while removing entities.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while removing entities due to {ex.Message}"));
			}
		}

        [HttpPost("SaveProduct")]
		// public async Task<ActionResult<bool>> SaveWorkOrderClientAgreementProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> SaveWorkOrderClientAgreementProduct([FromBody] WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
		{
			//bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementProduct(workOrderClientAgreementEntityProduct, ct);
			//return Ok(result);

			_logger.LogInformation("SaveWorkOrderClientAgreementProduct called. ProductId={Id}", workOrderClientAgreementEntityProduct?.WorkOrderClientAgreementEntityProductId ?? 0);

			if (workOrderClientAgreementEntityProduct == null)
			{
				_logger.LogWarning("SaveWorkOrderClientAgreementProduct validation failed: null payload.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid payload."));
			}

			try
			{
				bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementProduct(workOrderClientAgreementEntityProduct, ct);
				if (!result)
				{
					_logger.LogWarning("SaveWorkOrderClientAgreementProduct failed.");
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to save product."));
				}

				_logger.LogInformation("SaveWorkOrderClientAgreementProduct succeeded. ProductId={Id}", workOrderClientAgreementEntityProduct.WorkOrderClientAgreementEntityProductId);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveWorkOrderClientAgreementProduct request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving product.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving product due to {ex.Message}"));
			}
		}
        [HttpPost("saveVesselbyId")]
		// public async Task<ActionResult<bool>> SaveWorkOrderClientAgreementEntityByEntityId(WorkOrderClientAgreementEntity workOrderClientAgreementEntity, int woClientAgreementId, int workOrderId, bool hasAdditionalDiscounts, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> SaveWorkOrderClientAgreementEntityByEntityId([FromBody] WorkOrderClientAgreementEntity workOrderClientAgreementEntity, [FromQuery] int woClientAgreementId, [FromQuery] int workOrderId, [FromQuery] bool hasAdditionalDiscounts = false, CancellationToken ct = default)
		{
			//bool result=false;
			//if (workOrderClientAgreementEntity != null && workOrderClientAgreementEntity.WorkOrderClientAgreementId > 0)
			//{
			//    result = await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityByEntityId(workOrderClientAgreementEntity, woClientAgreementId, workOrderId, hasAdditionalDiscounts, ct);
			//}
			//return Ok(result);

			_logger.LogInformation("SaveWorkOrderClientAgreementEntityByEntityId called. WoClientAgreementId={WoId}, WorkOrderId={WorkOrderId}, EntityId={EntityId}", woClientAgreementId, workOrderId, workOrderClientAgreementEntity?.WorkOrderClientAgreementId ?? 0);

			if (workOrderClientAgreementEntity == null || workOrderClientAgreementEntity.WorkOrderClientAgreementId <= 0)
			{
				_logger.LogWarning("SaveWorkOrderClientAgreementEntityByEntityId validation failed.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid entity or WorkOrderClientAgreementId."));
			}

			try
			{
				bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityByEntityId(workOrderClientAgreementEntity, woClientAgreementId, workOrderId, hasAdditionalDiscounts, ct);
				if (!result)
				{
					_logger.LogWarning("SaveWorkOrderClientAgreementEntityByEntityId failed.");
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to save vessel entity by id."));
				}

				_logger.LogInformation("SaveWorkOrderClientAgreementEntityByEntityId succeeded. EntityId={EntityId}", workOrderClientAgreementEntity.WorkOrderClientAgreementId);
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveWorkOrderClientAgreementEntityByEntityId request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving vessel entity by id.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving vessel entity due to {ex.Message}"));
			}
		}
        [HttpPost("saveVessels")]
		// public async Task<ActionResult<bool>> SaveWorkOrderClientAgreementVesselEntities(WorkOrderClientAgreementViewModel workOrderClientAgreementViewModel, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<bool>>> SaveWorkOrderClientAgreementVesselEntities([FromBody] WorkOrderClientAgreementViewModel workOrderClientAgreementViewModel, CancellationToken ct = default)
		{
			//bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementVesselEntities(workOrderClientAgreementViewModel, ct);
			//return Ok(result);

			_logger.LogInformation("SaveWorkOrderClientAgreementVesselEntities called. ");

			if (workOrderClientAgreementViewModel == null)
			{
				_logger.LogWarning("SaveWorkOrderClientAgreementVesselEntities validation failed: null payload.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid payload."));
			}

			try
			{
				bool result = await _clientAgreementRepository.SaveWorkOrderClientAgreementVesselEntities(workOrderClientAgreementViewModel, ct);
				if (!result)
				{
					_logger.LogWarning("SaveWorkOrderClientAgreementVesselEntities failed.");
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to save vessel entities."));
				}

				_logger.LogInformation("SaveWorkOrderClientAgreementVesselEntities succeeded.");
				return Ok(ApiResponseDTO<bool>.Ok(true));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveWorkOrderClientAgreementVesselEntities request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving vessel entities.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving vessel entities due to {ex.Message}"));
			}
		}
        [HttpPost("updateVesselbyId")]
		// public async Task<ActionResult<WorkOrderClientAgreementEntity>> SaveWorkOrderClientAgreementEntity(WorkOrderClientAgreementEntity workOrderClientAgreementEntity, int woClientAgreementId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<WorkOrderClientAgreementEntity>>> SaveWorkOrderClientAgreementEntity([FromBody] WorkOrderClientAgreementEntity workOrderClientAgreementEntity, [FromQuery] int woClientAgreementId, CancellationToken ct = default)
		{
			// return await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityById(workOrderClientAgreementEntity, woClientAgreementId, ct);
			_logger.LogInformation("SaveWorkOrderClientAgreementEntity called. WoClientAgreementId={WoId}, EntityId={EntityId}", woClientAgreementId, workOrderClientAgreementEntity?.WorkOrderClientAgreementId ?? 0);

			if (workOrderClientAgreementEntity == null)
			{
				_logger.LogWarning("SaveWorkOrderClientAgreementEntity validation failed: null payload.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid payload."));
			}

			try
			{
				var saved = await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityById(workOrderClientAgreementEntity, woClientAgreementId, ct);
				if (saved == null)
				{
					_logger.LogWarning("SaveWorkOrderClientAgreementEntity failed to save/update entity. WoClientAgreementId={WoId}", woClientAgreementId);
					return StatusCode(500, ApiResponseDTO<string>.Fail("Failed to save/update vessel entity."));
				}

				_logger.LogInformation("SaveWorkOrderClientAgreementEntity succeeded. EntityId={EntityId}", saved.WorkOrderClientAgreementId);
				return Ok(ApiResponseDTO<WorkOrderClientAgreementEntity>.Ok(saved));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveWorkOrderClientAgreementEntity request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving/updating vessel entity.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving/updating vessel entity due to {ex.Message}"));
			}
		}
        [HttpPost("update-entity-products")]
		//  public async Task<ActionResult<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>> SaveWorkOrderClientAgreementEntityProducts(List<WorkOrderClientAgreementEntityProduct> lWorkOrderClientAgreementEntityProducts, int woClientAgreementId, int entityId, int systemDiscountScheduleId, bool isCustomFees, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>>> SaveWorkOrderClientAgreementEntityProducts(
			[FromBody] List<WorkOrderClientAgreementEntityProduct> lWorkOrderClientAgreementEntityProducts,
			[FromQuery] int woClientAgreementId,
			[FromQuery] int entityId,
			[FromQuery] int systemDiscountScheduleId,
			[FromQuery] bool isCustomFees,
			CancellationToken ct = default)
		{
			//var _entityProducts= await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityProducts(lWorkOrderClientAgreementEntityProducts, woClientAgreementId, entityId, systemDiscountScheduleId, isCustomFees, ct);
			//return Ok(_entityProducts);

			_logger.LogInformation("SaveWorkOrderClientAgreementEntityProducts called. WoClientAgreementId={WoId}, EntityId={EntityId}, Count={Count}", woClientAgreementId, entityId, lWorkOrderClientAgreementEntityProducts?.Count ?? 0);

			if (lWorkOrderClientAgreementEntityProducts == null)
			{
				_logger.LogWarning("SaveWorkOrderClientAgreementEntityProducts validation failed: null payload.");
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid payload."));
			}

			try
			{
				var entityProducts = await _clientAgreementRepository.SaveWorkOrderClientAgreementEntityProducts(lWorkOrderClientAgreementEntityProducts, woClientAgreementId, entityId, systemDiscountScheduleId, isCustomFees, ct);
				_logger.LogInformation("SaveWorkOrderClientAgreementEntityProducts succeeded. ReturnedCount={Count}", entityProducts?.Count ?? 0);
				return Ok(ApiResponseDTO<IReadOnlyList<WorkOrderClientAgreementEntityProduct>>.Ok(entityProducts));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "SaveWorkOrderClientAgreementEntityProducts request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while saving entity products.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while saving entity products due to {ex.Message}"));
			}
		}
    }
}
