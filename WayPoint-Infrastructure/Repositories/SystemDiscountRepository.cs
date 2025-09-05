using Microsoft.Data.SqlClient;
using System.Data;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;
using WayPoint_Infrastructure.StoredProcedures;
using WayPoint_Models;

namespace WayPoint_Infrastructure.Repositories
{
    public class SystemDiscountRepository(ISqlRunner sql) : ISystemDiscountRepository
    {
        private readonly ISqlRunner _sql = sql;

        public async Task<IReadOnlyList<SystemDiscountScheduleDto>> GetDiscountSchedulesAsync(
            int workOrderId, int systemDiscountProgramId, CancellationToken ct = default)
        {
            var agreementParams = new[]
            {
            new SqlParameter("@WorkOrderId", SqlDbType.Int) { Value = workOrderId }
        };

            var agreements = await _sql.QueryProcAsync<WorkOrderClientAgreement, WorkOrderClientAgreementDto>(
                SqlVerb.Get,
                parameters: agreementParams,
                map: r => new WorkOrderClientAgreementDto
                {
                    WorkOrderId = r.HasColumn("WorkOrderId") && !r.IsDBNull(r.GetOrdinal("WorkOrderId")) ? r.GetInt32(r.GetOrdinal("WorkOrderId")) : workOrderId,
                    SystemDiscountProgramId = r.HasColumn("SystemDiscountProgramId") && !r.IsDBNull(r.GetOrdinal("SystemDiscountProgramId")) ? r.GetInt32(r.GetOrdinal("SystemDiscountProgramId")) : systemDiscountProgramId,
                    IsMLCOption = r.HasColumn("IsMLCOption") && !r.IsDBNull(r.GetOrdinal("IsMLCOption")) && r.GetBoolean(r.GetOrdinal("IsMLCOption")),
                    IsISMOption = r.HasColumn("IsISMOption") && !r.IsDBNull(r.GetOrdinal("IsISMOption")) && r.GetBoolean(r.GetOrdinal("IsISMOption")),
                    IsISPSOption = r.HasColumn("IsISPSOption") && !r.IsDBNull(r.GetOrdinal("IsISPSOption")) && r.GetBoolean(r.GetOrdinal("IsISPSOption"))
                },
                ct: ct
            );

            var agreement = agreements.FirstOrDefault();
            if (agreement == null)
                return [];

            var schedulesParams = new[]
            {
            new SqlParameter("@SystemDiscountProgramId", SqlDbType.Int) { Value = agreement.SystemDiscountProgramId },
            new SqlParameter("@MLC", SqlDbType.Bit) { Value = agreement.IsMLCOption },
            new SqlParameter("@ISM", SqlDbType.Bit) { Value = agreement.IsISMOption },
            new SqlParameter("@ISPS", SqlDbType.Bit) { Value = agreement.IsISPSOption }
        };

            var schedules = await _sql.QueryProcAsync<SystemDiscountSchedules, SystemDiscountScheduleDto>(
                SqlVerb.Get,
                parameters: schedulesParams,
                map: r => new SystemDiscountScheduleDto
                {
                    SystemDiscountScheduleId = r.HasColumn("SystemDiscountScheduleId") && !r.IsDBNull(r.GetOrdinal("SystemDiscountScheduleId")) ? r.GetInt32(r.GetOrdinal("SystemDiscountScheduleId")) : 0,
                    Name = r.HasColumn("Name") && !r.IsDBNull(r.GetOrdinal("Name")) ? r.GetString(r.GetOrdinal("Name")) : string.Empty
                },
                ct: ct
            );

            return schedules;
        }
    }
}
