using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class SystemDiscountRepository : ISystemDiscountRepository
    {
        private readonly ISqlEngine _sql;

        public SystemDiscountRepository(ISqlEngine sql)
        {
            _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        }

        public async Task<IReadOnlyList<SystemDiscountSchedules>> GetDiscountSchedules(
            int workOrderId,
            int systemDiscountProgramId,
            CancellationToken ct = default)
        {
            // null/empty default result
            var empty = Array.Empty<SystemDiscountSchedules>();
            systemDiscountProgramId = 3;
            // fetch agreement (pass anonymous object for parameter)
            var workOrderClientAgreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(
                new { WorkOrderId = workOrderId },
                ct);

            // If none found, return empty list
            if (workOrderClientAgreement == null)
                return empty;

            // fetch discount schedules using values from agreement
            var discountSchedules = await _sql.RetrieveObjectsAsync<SystemDiscountSchedules>(
                new
                {
                    SystemDiscountProgramId = systemDiscountProgramId,
                    MLC = workOrderClientAgreement.IsMLCOption,
                    ISM = workOrderClientAgreement.IsISMOption,
                    ISPS = workOrderClientAgreement.IsISPSOption
                },
                ct);

            // if the engine returns null (defensive), return empty
            return discountSchedules ?? empty;
        }

        public async Task<IReadOnlyList<SystemDiscountScheduleProducts>> GetDiscountScheduleProducts(
           int systemDiscountScheduleId,
           CancellationToken ct = default)
        {
            // null/empty default result
            var empty = Array.Empty<SystemDiscountScheduleProducts>();

            // fetch agreement (pass anonymous object for parameter)
            var discountProducts = await _sql.RetrieveObjectsAsync<SystemDiscountScheduleProducts>(
                new { SystemDiscountScheduleId = systemDiscountScheduleId },
                ct);

            // If none found, return empty list
            if (discountProducts == null)
                return empty;

            return discountProducts.OrderBy(x => x.DefaultOrder).ToList();
        }

        public async Task<IReadOnlyList<SystemProductDiscountGroup>> GetSystemProductDiscountGroupByName(
          string systemProductName,
          CancellationToken ct = default)
        {
            var empty = Array.Empty<SystemProductDiscountGroup>();

            var discountProductsdiscount = await _sql.RetrieveObjectsAsync<SystemProductDiscountGroup>(
                new { SystemProductNameSearchText = systemProductName },
                ct);

            if (discountProductsdiscount == null)
                return empty;

            return discountProductsdiscount ?? empty;
        }
    }
}
