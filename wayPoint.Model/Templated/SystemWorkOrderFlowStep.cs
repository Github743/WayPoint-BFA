using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WayPoint.Model
{
    public partial class SystemWorkOrderFlowStep : BaseModel
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

        ///<summary>
        /// Get or Set the SystemWorkOrderFlowStepId Property of SystemWorkOrderFlowStep
        /// SystemWorkOrderFlowStepId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Flow Step Id")]
        public int SystemWorkOrderFlowStepId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderFlowId Property of SystemWorkOrderFlowStep
        /// SystemWorkOrderFlowId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Flow Id")]
        public int SystemWorkOrderFlowId { get; set; }

        ///<summary>
        /// Get or Set the StepName Property of SystemWorkOrderFlowStep
        /// StepName is Not Nullable
        ///</summary>


        [DisplayName("Step Name")]
        public int StepName { get; set; }

        ///<summary>
        /// Get or Set the Order Property of SystemWorkOrderFlowStep
        /// Order is Not Nullable
        ///</summary>


        [DisplayName("Order")]
        public int Order { get; set; }

        ///<summary>
        /// Get or Set the NeedValidation Property of SystemWorkOrderFlowStep
        /// NeedValidation is Not Nullable
        ///</summary>


        [DisplayName("Need Validation")]
        public bool NeedValidation { get; set; }

        ///<summary>
        /// Get or Set the ShowContinueButton Property of SystemWorkOrderFlowStep
        /// ShowContinueButton is Not Nullable
        ///</summary>


        [DisplayName("Show Continue Button")]
        public bool ShowContinueButton { get; set; }

        ///<summary>
        /// Get or Set the ContinueButtonText Property of SystemWorkOrderFlowStep
        /// ContinueButtonText is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Continue Button Text")]
        public string ContinueButtonText { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ShowRejectionButton Property of SystemWorkOrderFlowStep
        /// ShowRejectionButton is Not Nullable
        ///</summary>


        [DisplayName("Show Rejection Button")]
        public bool ShowRejectionButton { get; set; }

        ///<summary>
        /// Get or Set the RejectionButtonText Property of SystemWorkOrderFlowStep
        /// RejectionButtonText is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Rejection Button Text")]
        public string RejectionButtonText { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the InternalReadOnlyMode Property of SystemWorkOrderFlowStep
        /// InternalReadOnlyMode is Not Nullable
        ///</summary>


        [DisplayName("Internal Read Only Mode")]
        public bool InternalReadOnlyMode { get; set; }

        ///<summary>
        /// Get or Set the ExternalReadOnlyMode Property of SystemWorkOrderFlowStep
        /// ExternalReadOnlyMode is Not Nullable
        ///</summary>


        [DisplayName("External Read Only Mode")]
        public bool ExternalReadOnlyMode { get; set; }

        ///<summary>
        /// Get or Set the CanInternalAdvance Property of SystemWorkOrderFlowStep
        /// CanInternalAdvance is Not Nullable
        ///</summary>


        [DisplayName("Can Internal Advance")]
        public bool CanInternalAdvance { get; set; }

        ///<summary>
        /// Get or Set the CanExternalAdvance Property of SystemWorkOrderFlowStep
        /// CanExternalAdvance is Not Nullable
        ///</summary>


        [DisplayName("Can External Advance")]
        public bool CanExternalAdvance { get; set; }

        ///<summary>
        /// Get or Set the NeedReview Property of SystemWorkOrderFlowStep
        /// NeedReview is Not Nullable
        ///</summary>


        [DisplayName("Need Review")]
        public bool NeedReview { get; set; }

        ///<summary>
        /// Get or Set the ShowCartButton Property of SystemWorkOrderFlowStep
        /// ShowCartButton is Not Nullable
        ///</summary>


        [DisplayName("Show Cart Button")]
        public bool ShowCartButton { get; set; }

        ///<summary>
        /// Get or Set the ShowRereviewButton Property of SystemWorkOrderFlowStep
        /// ShowRereviewButton is Not Nullable
        ///</summary>


        [DisplayName("Show Rereview Button")]
        public bool ShowRereviewButton { get; set; }

        ///<summary>
        /// Get or Set the ShowDeleteButton Property of SystemWorkOrderFlowStep
        /// ShowDeleteButton is Not Nullable
        ///</summary>


        [DisplayName("Show Delete Button")]
        public bool ShowDeleteButton { get; set; }

        ///<summary>
        /// Get or Set the ShowRefreshButton Property of SystemWorkOrderFlowStep
        /// ShowRefreshButton is Not Nullable
        ///</summary>


        [DisplayName("Show Refresh Button")]
        public bool ShowRefreshButton { get; set; }

        ///<summary>
        /// Get or Set the ShowActivateButton Property of SystemWorkOrderFlowStep
        /// ShowActivateButton is Not Nullable
        ///</summary>


        [DisplayName("Show Activate Button")]
        public bool ShowActivateButton { get; set; }

        #endregion
    }
}
