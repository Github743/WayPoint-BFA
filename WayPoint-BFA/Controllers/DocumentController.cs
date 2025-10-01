using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WayPoint.Model;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_BFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController(IDocuments document) : ControllerBase
    {
        private readonly IDocuments _document = document;

        [HttpGet("outgoingDocuments/{workOrderId:int}")]
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> GetOutgoingDocuments(int workOrderId, CancellationToken ct = default)
        {
            bool isLiscr = true;
            var lOutgoingDocuments = await _document.GetWorkOrderFiles(workOrderId, 0,false,false, isLiscr);
            if (lOutgoingDocuments == null || lOutgoingDocuments.Count == 0)
                return Array.Empty<WorkOrderDocumentDetail>();
           
            if (lOutgoingDocuments.Count>0 && lOutgoingDocuments[0].IsLiscr)
                lOutgoingDocuments = lOutgoingDocuments.Where(w => w.CanShowForExternal).ToList();

            return lOutgoingDocuments.OrderByDescending(x => x.DefaultOrder.HasValue).ThenBy(x => x.DefaultOrder).ThenBy(x => x.DisplayName).ToList(); 
        }
        [HttpGet("supportingDocuments/{workOrderId:int}")]
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> GetSupportingDocuments(int workOrderId, int workOrderItemEntityId, bool isLiscr, bool hasPostclosingDocs = false, CancellationToken ct = default)
        {
            var lsupportingDocuments = await _document.GetWorkOrderFiles(workOrderId, workOrderItemEntityId,true, isLiscr);
            if (!isLiscr)
                lsupportingDocuments = lsupportingDocuments.Where(m => m.CanExternalUploadOrDelete).ToList();

            if (hasPostclosingDocs)
                lsupportingDocuments = lsupportingDocuments.Where(x => x.IsPostClosing).ToList();
            else
                lsupportingDocuments = lsupportingDocuments.Where(x => !x.IsMerge).ToList();
            return lsupportingDocuments.OrderByDescending(x => x.DefaultOrder.HasValue).ThenBy(x => x.DefaultOrder).ThenBy(x => x.DisplayName).ToList();
        }
        [HttpGet("additionalsupportingDocuments/{workOrderId:int}")]
        public async Task<IReadOnlyList<WorkOrderAdditionalDocument>> GetAdditionalSupportingDocuments(int workOrderId, bool isInternal, string docTypeName = null, CancellationToken ct = default)
        {
            var result = await _document.GetWorkOrderAdditionalDocuments(workOrderId, isInternal, docTypeName, ct);
            return result;
        }
        [HttpGet("emailAttachments/{workOrderId:int}")]
        public async Task<IReadOnlyList<WorkOrderEmail>> GetAdditionalSupportingDocuments(int workOrderId, CancellationToken ct = default)
        {
            var result = await _document.GetWorkorderEmailAttachments(workOrderId, ct);
            return result;
        }
        [HttpGet("notesDocument/{workorderId:int}")]
        public async Task<IReadOnlyList<EntityNote>> GetNotes(int workorderId, string? noteSubType, CancellationToken ct = default)
        {
           return await _document.GetEntityNoteByEntityId(workorderId, noteSubType,ct);
        }
        [HttpGet("orderShipment/{workorderId:int}")]
        public async Task<IReadOnlyList<OrderShipment>> GetOrderShipment(int workorderId,CancellationToken ct = default)
        {
            return await _document.GetOrderShipmentDetails(workorderId,ct);
        }
    }
}
