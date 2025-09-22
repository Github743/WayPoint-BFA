using Microsoft.EntityFrameworkCore;

namespace WayPoint.Model
{
    public class WayPointDbContext : DbContext
    {
        public WayPointDbContext(DbContextOptions<WayPointDbContext> options)
            : base(options) { }

        public DbSet<WorkOrderSettingField> WorkOrderSettingFields { get; set; }
        public DbSet<SystemWorkOrderSettingField> SystemWorkOrderSettingFields { get; set; }


    }
}
