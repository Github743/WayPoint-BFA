using System.ComponentModel;

namespace WayPoint.Model
{
    public partial  class WorkOrderItem : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the WorkOrderItemId Property of WorkOrderItem
        /// WorkOrderItemId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Id")]
        public int WorkOrderItemId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderXrefItemId Property of WorkOrderItem
        /// SystemWorkOrderXrefItemId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Xref Item Id")]
        public int SystemWorkOrderXrefItemId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of WorkOrderItem
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        #endregion
    }
}
