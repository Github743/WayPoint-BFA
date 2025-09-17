using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    [Table("WorkOrderSettingField", Schema = "WO")]
    public partial class WorkOrderSettingField : BaseModel
    {
        #region Properties

        public WorkOrderSettingField()
        {
           // SystemWorkOrderSetting = new SystemWorkOrderSetting();
           // SystemWorkOrderSettingField = new SystemWorkOrderSettingField();
        }

        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        }

        public int WorkOrderSettingFieldId { get; set; }

        public int WorkOrderId { get; set; }

        public int SystemWorkOrderSettingId { get; set; }

        public int SystemWorkOrderSettingFieldId { get; set; }

        public string? Value { get; set; }

       // public virtual SystemWorkOrderSetting SystemWorkOrderSetting { get; set; }

        //public virtual SystemWorkOrderSettingField SystemWorkOrderSettingField { get; set; }

        #endregion
    }
}
