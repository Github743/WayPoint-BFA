using WayPoint.Model;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class SystemWorkOrderRepository(ISqlEngine sql) : ISystemWorkOrderRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));

        public async Task<SystemWorkOrder> SearchAsync(
            string systemWorkOrderName, CancellationToken ct = default)
        {
            var result = await _sql.RetrieveObjectAsync<SystemWorkOrder>(
                new { SystemWorkOrderName = systemWorkOrderName },
                ct
            );

            return result;
        }
    }
}
