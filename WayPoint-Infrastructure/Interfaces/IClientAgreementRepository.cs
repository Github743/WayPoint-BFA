using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using WayPoint.Model;

namespace WayPoint_Infrastructure.Interfaces
{
    public interface IClientAgreementRepository
    {
        Task<bool> SaveEntityProducts(List<WorkOrderClientAgreementEntityProduct> workOrderClientAgreementEntityProducts, int workOrderId, int systemDiscountScheduleId, CancellationToken ct = default);

        Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> GetWorkOrderClientAgreementEntityProducts(int workOrderId, CancellationToken ct = default);

        Task<WorkOrderClientAgreement> GetWorkOrderClientAgreement(int workOrderId, CancellationToken ct = default);
        
        Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> GetAdditionalDiscountedProducts(int workOrderId, CancellationToken ct = default);

        Task<bool> UpdateEntityProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default);

        Task<bool> RemoveEntityProduct(int workOrderClientAgreementEntityProductId, CancellationToken ct = default);

        Task<bool> RemoveEntityProducts(int[] ids, CancellationToken ct = default);

        Task<bool> SaveWorkOrderClientAgreementProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default);
    }
}
