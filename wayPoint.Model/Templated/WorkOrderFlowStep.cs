using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderFlowStep : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        [DbIgnore]
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        } // end of schema name property

        ///<summary>
        /// Get or Set the WorkOrderFlowStepId Property of WorkOrderFlowStep
        /// WorkOrderFlowStepId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Flow Step Id")]
        public int WorkOrderFlowStepId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of WorkOrderFlowStep
        /// WorkOrderId is Nullable 
        ///</summary>


        [DisplayName("Work Order Id")]
        public int? WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the FlowStartDate Property of WorkOrderFlowStep
        /// FlowStartDate is Not Nullable
        ///</summary>


        [DisplayName("Flow Start Date")]
        public DateTime FlowStartDate { get; set; }

        ///<summary>
        /// Get or Set the FlowEndDate Property of WorkOrderFlowStep
        /// FlowEndDate is Nullable 
        ///</summary>


        [DisplayName("Flow End Date")]
        public DateTime? FlowEndDate { get; set; }

        ///<summary>
        /// Get or Set the FlowStepId Property of WorkOrderFlowStep
        /// FlowStepId is Nullable 
        ///</summary>


        [DisplayName("Flow Step Id")]
        public int? FlowStepId { get; set; }

        #endregion
    }
}
