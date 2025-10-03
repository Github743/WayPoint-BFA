using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface IDocuments
    {
        Task<IReadOnlyList<WorkOrderDocumentDetail>> GetWorkOrderFiles(int workOrderId, int workOrderItemEntityId, bool isSupporting, bool hasPostclosingDocs = false, bool isLiscr = true, CancellationToken ct = default);
        Task<IReadOnlyList<WorkOrderDocumentDetail>> GetListOfWorkOrderDocuments(int workOrderId, string documentName = "", bool isOutgoing = true, bool isRequired = true, bool isLiscrUser = false, CancellationToken ct = default);
        Task<IReadOnlyList<WorkOrderAdditionalDocument>> GetWorkOrderAdditionalDocuments(int workOrderId, bool isInternal, string docTypeName = null, CancellationToken ct = default);
        Task<IReadOnlyList<WorkOrderEmail>> GetWorkorderEmailAttachments(int workOrderId, CancellationToken ct = default);
        Task<IReadOnlyList<EntityNote>> GetEntityNoteByEntityId(int workorderId, string noteSubType, CancellationToken ct = default);
        Task<IReadOnlyList<OrderShipment>> GetOrderShipmentDetails(int workorderId, CancellationToken ct = default);
    }
}
