using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderItemEntity: BaseModel
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
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderItemEntity
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemId Property of WorkOrderItemEntity
        /// WorkOrderItemId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Id")]
        public int WorkOrderItemId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderEntityId Property of WorkOrderItemEntity
        /// WorkOrderEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        ///<summary>
        /// Get or Set the ChildEntityId Property of WorkOrderItemEntity
        /// ChildEntityId is Nullable 
        ///</summary>


        [DisplayName("Child Entity Id")]
        public int? ChildEntityId { get; set; }

        ///<summary>
        /// Get or Set the LISActivityItemId Property of WorkOrderItemEntity
        /// LISActivityItemId is Nullable 
        ///</summary>


        [DisplayName("LIS Activity Item Id")]
        public int? LISActivityItemId { get; set; }

        ///<summary>
        /// Get or Set the LISActivityItemType Property of WorkOrderItemEntity
        /// LISActivityItemType is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("LIS Activity Item Type")]
        public string? LISActivityItemType { get; set; }

        [DbIgnore]
        [DisplayName("Display Name")]
        public string? DisplayName { get; set; }

        #endregion
    }
}
