using Microsoft.EntityFrameworkCore;

namespace WayPoint.Model
{
    public class WayPointDbContext : DbContext
    {
        public WayPointDbContext(DbContextOptions<WayPointDbContext> options)
            : base(options) { }

        public DbSet<WorkOrderSettingField> WorkOrderSettingFields { get; set; }
        public DbSet<SystemWorkOrderSettingField> SystemWorkOrderSettingFields { get; set; }
        public DbSet<WorkOrderClientAgreementEntityProduct> WorkOrderClientAgreementEntityProducts { get; set; }
        public DbSet<WorkOrderEntity> WorkOrderEntity { get; set; }
        public DbSet<WorkOrderVessel> WorkOrderVessels { get; set; }
        public DbSet<WorkOrderVesselClient> WorkOrderVesselClients { get; set; }
        public DbSet<WorkOrderClientAgreementEntity> WorkOrderClientAgreementEntities { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<WorkOrderClientAgreement> WorkOrderClientAgreementies { get; set; }
        public DbSet<WorkOrderDocument> WorkOrderDocuments { get; set; }
        
    }
}
