using System.ComponentModel;

namespace WayPoint.Model
{
    public  partial class SystemWorkOrderTypeFlow : BaseModel
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
        /// Get or Set the SystemWorkOrderTypeFlowId Property of SystemWorkOrderTypeFlow
        /// SystemWorkOrderTypeFlowId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Type Flow Id")]
        public int SystemWorkOrderTypeFlowId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderId Property of SystemWorkOrderTypeFlow
        /// SystemWorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Id")]
        public int SystemWorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderFlowId Property of SystemWorkOrderTypeFlow
        /// SystemWorkOrderFlowId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Flow Id")]
        public int SystemWorkOrderFlowId { get; set; }

        ///<summary>
        /// Get or Set the IsInternal Property of SystemWorkOrderTypeFlow
        /// IsInternal is Not Nullable
        ///</summary>


        [DisplayName("Is Internal")]
        public bool IsInternal { get; set; }

        ///<summary>
        /// Get or Set the IsManualFeeApplicable Property of SystemWorkOrderTypeFlow
        /// IsManualFeeApplicable is Not Nullable
        ///</summary>


        [DisplayName("Is Manual Fee Applicable")]
        public bool IsManualFeeApplicable { get; set; }

        ///<summary>
        /// Get or Set the IsRefreshRequired Property of SystemWorkOrderTypeFlow
        /// IsRefreshRequired is Not Nullable
        ///</summary>


        [DisplayName("Is Refresh Required")]
        public bool IsRefreshRequired { get; set; }

        #endregion
    }
}
