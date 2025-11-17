using Microsoft.AspNetCore.Mvc;
using System.Net;
using WayPoint.Model;
using WayPoint.Model.Common;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
	[ApiController]
	[Route("api")]
	public class ClientController : ControllerBase
	{
		private readonly IClientRepository _service;
		private readonly ILogger<ClientController> _logger;

		public ClientController(IClientRepository service, ILogger<ClientController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet("clients")]
		// public async Task<ActionResult<IReadOnlyList<ClientDetail>>> GetClients([FromQuery] string? clientSearch, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<IReadOnlyList<ClientDetail>>>> GetClients([FromQuery] string? clientSearch, CancellationToken ct = default)
		{
			//if (string.IsNullOrWhiteSpace(clientSearch)) return BadRequest("Search text is mandaotry");
			//var rows = await _service.GetClientsAsync(clientSearch, ct);
			//return Ok(rows);

			_logger.LogInformation("GetClients called. Search='{ClientSearch}'", clientSearch);

			if (string.IsNullOrWhiteSpace(clientSearch))
			{
				_logger.LogWarning("GetClients validation failed: search text is empty.");
				return BadRequest(ApiResponseDTO<string>.Fail("Search text is mandatory."));
			}

			try
			{
				var rows = await _service.GetClientsAsync(clientSearch, ct);

				if (rows is IReadOnlyList<ClientDetail> list)
					_logger.LogInformation("GetClients succeeded. ReturnedCount={Count}", list.Count);

				return Ok(ApiResponseDTO<IReadOnlyList<ClientDetail>>.Ok(rows));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetClients request was canceled.");
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				//return HandleException(ex, "Error while fetching clients.");
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching clients due to {ex.Message}"));
			}
		}

		[HttpGet("Client/{clientId:int}")]
		// public async Task<ActionResult<ClientDetail>> GetClient(int clientId, CancellationToken ct = default)
		public async Task<ActionResult<ApiResponseDTO<Client>>> GetClient(int clientId, CancellationToken ct = default)
		{
			//var client = await _service.GetClient(clientId, ct);

			//if (client == null)
			//    return NotFound();

			//return Ok(client);
			_logger.LogInformation("GetClient called. ClientId={ClientId}", clientId);

			if (clientId <= 0)
			{
				_logger.LogWarning("GetClient validation failed: invalid clientId {ClientId}", clientId);
				return BadRequest(ApiResponseDTO<string>.Fail("Invalid client id."));
			}

			try
			{
				var client = await _service.GetClient(clientId, ct);
				if (client == null)
				{
					_logger.LogInformation("GetClient: client not found. ClientId={ClientId}", clientId);
					return NotFound(ApiResponseDTO<string>.Fail("Client not found."));
				}

				_logger.LogInformation("GetClient succeeded. ClientId={ClientId}", clientId);
				return Ok(ApiResponseDTO<Client>.Ok(client));
			}
			catch (OperationCanceledException oce)
			{
				_logger.LogWarning(oce, "GetClient request was canceled. ClientId={ClientId}", clientId);
				return StatusCode(499, ApiResponseDTO<string>.Fail("Request was cancelled."));
			}
			catch (Exception ex)
			{
				return StatusCode(500, ApiResponseDTO<string>.Fail($"Error while fetching client (ClientId={clientId})  due to {ex.Message}"));

			}

		}

	}
}
