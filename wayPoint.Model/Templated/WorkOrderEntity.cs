using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderEntity : BaseModel
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
        /// Get or Set the WorkOrderEntityId Property of WorkOrderEntity
        /// WorkOrderEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of WorkOrderEntity
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of WorkOrderEntity
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the IsChild Property of WorkOrderEntity
        /// IsChild is Not Nullable
        ///</summary>


        [DisplayName("Is Child")]
        public bool IsChild { get; set; }

        #endregion
    }
}
