using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class WorkOrder : BaseModel
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
        /// Get or Set the WorkOrderId Property of WorkOrder
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderId Property of WorkOrder
        /// SystemWorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Id")]
        public int SystemWorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the EstimatedClosingDate Property of WorkOrder
        /// EstimatedClosingDate is Nullable 
        ///</summary>


        [DisplayName("Estimated Closing Date")]
        public DateTime? EstimatedClosingDate { get; set; }

        ///<summary>
        /// Get or Set the EffectiveDate Property of WorkOrder
        /// EffectiveDate is Nullable 
        ///</summary>


        [DisplayName("Effective Date")]
        public DateTime? EffectiveDate { get; set; }

        ///<summary>
        /// Get or Set the CurrentStepId Property of WorkOrder
        /// CurrentStepId is Not Nullable
        ///</summary>


        [DisplayName("Current Step Id")]
        public int CurrentStepId { get; set; }

        ///<summary>
        /// Get or Set the AssignedTo Property of WorkOrder
        /// AssignedTo is Nullable 
        ///</summary>


        [DisplayName("Assigned To")]
        public int? AssignedTo { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of WorkOrder
        /// EntityId is Nullable 
        ///</summary>


        [DisplayName("Entity Id")]
        public int? EntityId { get; set; }

        ///<summary>
        /// Get or Set the Detail Property of WorkOrder
        /// Detail is Nullable 
        ///</summary>

        [StringLength(300)]
        [DisplayName("Detail")]
        public string? Detail { get; set; }

        ///<summary>
        /// Get or Set the Office Property of WorkOrder
        /// Office is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Office")]
        public string Office { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ActivationDate Property of WorkOrder
        /// ActivationDate is Nullable 
        ///</summary>


        [DisplayName("Activation Date")]
        public DateTime? ActivationDate { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderTypeFlowId Property of WorkOrder
        /// SystemWorkOrderTypeFlowId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Type Flow Id")]
        public int SystemWorkOrderTypeFlowId { get; set; }

        ///<summary>
        /// Get or Set the UserId Property of WorkOrder
        /// UserId is Nullable 
        ///</summary>


        [DisplayName("User Id")]
        public int? UserId { get; set; }

        ///<summary>
        /// Get or Set the EditVesselDetailsFlag Property of WorkOrder
        /// EditVesselDetailsFlag is Nullable 
        ///</summary>


        [DisplayName("Edit Vessel Details Flag")]
        public bool? EditVesselDetailsFlag { get; set; }

        ///<summary>
        /// Get or Set the LegacyActivityId Property of WorkOrder
        /// LegacyActivityId is Nullable 
        ///</summary>


        [DisplayName("Legacy Activity Id")]
        public int? LegacyActivityId { get; set; }

        ///<summary>
        /// Get or Set the LegacyActivityType Property of WorkOrder
        /// LegacyActivityType is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Legacy Activity Type")]
        public string LegacyActivityType { get; set; } = string.Empty;
        ///<summary>
        /// Get or Set the RequestedBy Property of WorkOrder
        /// RequestedBy is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Requested By")]
        public string RequestedBy { get; set; } = string.Empty;



        #endregion
    }
}
