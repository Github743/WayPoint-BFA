using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    [Table("SystemWorkOrderSettingField", Schema = "meta")]
    public class SystemWorkOrderSettingField : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "meta.usp_";
            }
        } // end of schema name property 

        public int SystemWorkOrderSettingFieldId { get; set; }

        public int SystemWorkOrderSettingId { get; set; }

        public string TableName { get; set; } = string.Empty;

        public string ColumnName { get; set; } = string.Empty;

        public virtual SystemWorkOrderSetting SystemWorkOrderSetting { get; set; }

        public virtual ICollection<WorkOrderSettingField> WorkOrderSettingFields { get; set; } = new List<WorkOrderSettingField>();

        #endregion
    }
}
