using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class DocumentRepository(ISqlEngine sql,IWorkOrderRepository workorder) : IDocuments
    {
        private readonly ISqlEngine _sql = sql;
        private readonly IWorkOrderRepository _workorder = workorder;
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> GetWorkOrderFiles(int workOrderId, int workOrderItemEntityId, bool isSupporting, bool hasPostclosingDocs = false, bool isLiscr = true, CancellationToken ct = default)
        {
            IReadOnlyList<WorkOrderDocumentDetail> _workorderDocFiles = new List<WorkOrderDocumentDetail>();
            if (isSupporting)
            {
                _workorderDocFiles = await GetListOfWorkOrderDocuments(workOrderId, "", false, true, isLiscr);
            }
            else
                _workorderDocFiles = await GetListOfWorkOrderDocuments(workOrderId, "", true, true, isLiscr);

            _workorderDocFiles = _workorderDocFiles.Where(a => !a.IsPostClosing && a.CanShow).ToList();
            _workorderDocFiles.ToList().ForEach(x => x.IsLiscr = isLiscr);
            foreach (var workOrderDoc in _workorderDocFiles)
            {
                if (Convert.ToBoolean(workOrderDoc.HasNotes))
                {
                    WorkOrderDocumentNote wokOrderDocumentNote = await _sql.RetrieveObjectAsync<WorkOrderDocumentNote>(
                        new { WorkOrderDocumentId = workOrderDoc.WorkOrderDocumentId }, ct);
                    if (wokOrderDocumentNote != null)
                    {
                        workOrderDoc.NoteId = wokOrderDocumentNote.NoteId;
                        workOrderDoc.WorkOrderDocumentNoteId = wokOrderDocumentNote.WorkOrderDocumentNoteId;
                        workOrderDoc.Text = wokOrderDocumentNote.Text;
                    }
                }
            }
            return _workorderDocFiles;
        }
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> GetListOfWorkOrderDocuments(int workOrderId, string documentName = "", bool isOutgoing = true, bool isRequired = true, bool isLiscrUser = false, CancellationToken ct = default)
        {
            IReadOnlyList<WorkOrderDocumentDetail> lwoDocuments = Array.Empty<WorkOrderDocumentDetail>();
            if (documentName == "" && isOutgoing == true)
            {
                lwoDocuments = await getOutgoingDocuments(workOrderId, isRequired, isLiscrUser);
            }
            else if (documentName == "" && isOutgoing == false)
            {
                lwoDocuments = await getSupportingDocuments(workOrderId, isRequired);
            }
            return lwoDocuments;
        }
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> getOutgoingDocuments(int workOrderId, bool isRequired, bool isLiscrUser, CancellationToken ct = default)
        {
            List<WorkOrderDocumentDetail> workOrderDocuments = new();
            IReadOnlyList<WorkOrderDocumentDetail> lAllWorkOrderDocuments = await _sql.RetrieveObjectsAsync<WorkOrderDocumentDetail>(
                new { WorkOrderId = workOrderId, IsRequired = isRequired }, ct);
            var lWorkOrderOutgoingDocumentsWithOutInterimInvoice = lAllWorkOrderDocuments.Where(x => (x.IsOutgoing == true && x.SystemWorkOrderItemName != ApplicationConstants.REREGISTRATION_SYSTEM_WORKORDER_ITEM_INTERIMOWNER_INVOICE) || (x.IsInternal == true && isLiscrUser)).ToList();
            workOrderDocuments.AddRange(lWorkOrderOutgoingDocumentsWithOutInterimInvoice);

            return workOrderDocuments;
        }
        public async Task<IReadOnlyList<WorkOrderDocumentDetail>> getSupportingDocuments(int workOrderId, bool isRequired, CancellationToken ct = default)
        {
            List<WorkOrderDocumentDetail> workOrderDocuments = new();
            IReadOnlyList<WorkOrderDocumentDetail> lAllWorkOrderDocuments = await _sql.RetrieveObjectsAsync<WorkOrderDocumentDetail>(
                new { WorkOrderId = workOrderId, FromClient = true }, ct);
            var lWorkOrderSupportingDocumentsWithOutInterimInvoice = lAllWorkOrderDocuments.Where(x => x.SystemWorkOrderItemName != ApplicationConstants.REREGISTRATION_SYSTEM_WORKORDER_ITEM_INTERIMOWNER).ToList();
            workOrderDocuments.AddRange(lWorkOrderSupportingDocumentsWithOutInterimInvoice);
            return workOrderDocuments;
        }
        public async Task<IReadOnlyList<WorkOrderAdditionalDocument>> GetWorkOrderAdditionalDocuments(int workOrderId, bool isInternal, string docTypeName, CancellationToken ct = default)
        {
            IReadOnlyList<WorkOrderAdditionalDocument> additionalworkOrderDocuments = await _sql.RetrieveObjectsAsync<WorkOrderAdditionalDocument>(
                new { WorkOrderId = workOrderId }, ct);

            return additionalworkOrderDocuments
                .Where(d => isInternal || !d.InternalOnly)
                .Where(d =>
                    !string.IsNullOrEmpty(docTypeName)
                        ? d.DocumentType == docTypeName
                        : d.DocumentTypeId == null)
                .ToList();
        }
        public async Task<IReadOnlyList<WorkOrderEmail>> GetWorkorderEmailAttachments(int workOrderId, CancellationToken ct = default)
        {
            IReadOnlyList<WorkOrderEmail> additionalworkOrderDocuments = await _sql.RetrieveObjectsAsync<WorkOrderEmail>(
                new { WorkOrderId = workOrderId }, ct);

            return additionalworkOrderDocuments;
        }
        public async Task<IReadOnlyList<EntityNote>> GetEntityNoteByEntityId(int workorderId, string noteSubType, CancellationToken ct = default)
        {
            noteSubType = ApplicationConstants.NOTESUBTYPE_WOOUTGOINGDOC;
            var workorder = await _workorder.GetWorkOrder(workorderId, ct);
            IReadOnlyList<EntityNote> _lentityNotes = await _sql.RetrieveObjectsAsync<EntityNote>(
                new { EntityId = workorder.EntityId, NoteTypeName = ApplicationConstants.NOTETYPE_NOTES }, ct);

            if (_lentityNotes == null)
                return Array.Empty<EntityNote>();

            return _lentityNotes
                .Where(n => n.NoteSubTypeLookupName == noteSubType)
                .ToList();
        }
        public async Task<IReadOnlyList<OrderShipment>> GetOrderShipmentDetails(int workorderId,CancellationToken ct = default)
        {
            return await _sql.RetrieveObjectsAsync<OrderShipment>(
                new { workorderId }, ct);
        }
    }
}
