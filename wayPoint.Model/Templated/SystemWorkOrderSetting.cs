using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    [Table("SystemWorkOrderSetting", Schema = "meta")]
    public partial class SystemWorkOrderSetting : BaseModel
    {
        public int SystemWorkOrderSettingId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string LoadActionName { get; set; } = string.Empty;

        public string LoadControllerName { get; set; } = string.Empty;

        public string SaveMethodName { get; set; } = string.Empty;

        public virtual ICollection<SystemWorkOrderSettingField> SystemWorkOrderSettingFields { get; set; } = new List<SystemWorkOrderSettingField>();

        public virtual ICollection<WorkOrderSettingField> WorkOrderSettingFields { get; set; } = new List<WorkOrderSettingField>();
    }
}
