using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class SystemWorkOrder : BaseModel
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
        /// Get or Set the SystemWorkOrderId Property of SystemWorkOrder
        /// SystemWorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Id")]
        public int SystemWorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the ParentSystemWorkOrderId Property of SystemWorkOrder
        /// ParentSystemWorkOrderId is Nullable 
        ///</summary>


        [DisplayName("Parent System Work Order Id")]
        public int? ParentSystemWorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of SystemWorkOrder
        /// Name is Not Nullable
        ///</summary>
        
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the DisplayName Property of SystemWorkOrder
        /// DisplayName is Not Nullable
        ///</summary>
        
        [StringLength(100)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Order Property of SystemWorkOrder
        /// Order is Not Nullable
        ///</summary>


        [DisplayName("Order")]
        public int Order { get; set; }

        ///<summary>
        /// Get or Set the ControllerName Property of SystemWorkOrder
        /// ControllerName is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Controller Name")]
        public string ControllerName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ActionName Property of SystemWorkOrder
        /// ActionName is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Action Name")]
        public string ActionName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the BusinessDepartmentId Property of SystemWorkOrder
        /// BusinessDepartmentId is Not Nullable
        ///</summary>


        [DisplayName("Business Department Id")]
        public int BusinessDepartmentId { get; set; }

        ///<summary>
        /// Get or Set the DefaultBillToClientRole Property of SystemWorkOrder
        /// DefaultBillToClientRole is Nullable 
        ///</summary>


        [DisplayName("Default Bill To Client Role")]
        public int? DefaultBillToClientRole { get; set; }

        ///<summary>
        /// Get or Set the NonLiberianActivity Property of SystemWorkOrder
        /// NonLiberianActivity is Not Nullable
        ///</summary>


        [DisplayName("Non Liberian Activity")]
        public bool NonLiberianActivity { get; set; }

        ///<summary>
        /// Get or Set the AllowThirdParty Property of SystemWorkOrder
        /// AllowThirdParty is Not Nullable
        ///</summary>


        [DisplayName("Allow Third Party")]
        public bool AllowThirdParty { get; set; }

        ///<summary>
        /// Get or Set the VesselContext Property of SystemWorkOrder
        /// VesselContext is Not Nullable
        ///</summary>


        [DisplayName("Vessel Context")]
        public bool VesselContext { get; set; }

        ///<summary>
        /// Get or Set the CorpContext Property of SystemWorkOrder
        /// CorpContext is Not Nullable
        ///</summary>


        [DisplayName("Corp Context")]
        public bool CorpContext { get; set; }

        ///<summary>
        /// Get or Set the ClientContext Property of SystemWorkOrder
        /// ClientContext is Not Nullable
        ///</summary>


        [DisplayName("Client Context")]
        public bool ClientContext { get; set; }

        ///<summary>
        /// Get or Set the AllowExternalUser Property of SystemWorkOrder
        /// AllowExternalUser is Not Nullable
        ///</summary>


        [DisplayName("Allow External User")]
        public bool AllowExternalUser { get; set; }

        ///<summary>
        /// Get or Set the AllowBulkActivity Property of SystemWorkOrder
        /// AllowBulkActivity is Not Nullable
        ///</summary>


        [DisplayName("Allow Bulk Activity")]
        public bool AllowBulkActivity { get; set; }

        ///<summary>
        /// Get or Set the ShowReviewedFlag Property of SystemWorkOrder
        /// ShowReviewedFlag is Not Nullable
        ///</summary>


        [DisplayName("Show Reviewed Flag")]
        public bool ShowReviewedFlag { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderClassName Property of SystemWorkOrder
        /// WorkOrderClassName is Nullable 
        ///</summary>

        [StringLength(500)]
        [DisplayName("Work Order Class Name")]
        public string WorkOrderClassName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the DisplayOnMenu Property of SystemWorkOrder
        /// DisplayOnMenu is Nullable 
        ///</summary>


        [DisplayName("Display On Menu")]
        public bool? DisplayOnMenu { get; set; }

        ///<summary>
        /// Get or Set the IsRegistrationWorkOrder Property of SystemWorkOrder
        /// IsRegistrationWorkOrder is Not Nullable
        ///</summary>


        [DisplayName("Is Registration Work Order")]
        public bool IsRegistrationWorkOrder { get; set; }

        ///<summary>
        /// Get or Set the PostClosingApplicable Property of SystemWorkOrder
        /// PostClosingApplicable is Not Nullable
        ///</summary>


        [DisplayName("Post Closing Applicable")]
        public bool PostClosingApplicable { get; set; }

        ///<summary>
        /// Get or Set the HasEdelivery Property of SystemWorkOrder
        /// HasEdelivery is Not Nullable
        ///</summary>


        [DisplayName("Has Edelivery")]
        public bool HasEdelivery { get; set; }

        ///<summary>
        /// Get or Set the HasCourier Property of SystemWorkOrder
        /// HasCourier is Not Nullable
        ///</summary>


        [DisplayName("Has Courier")]
        public bool HasCourier { get; set; }

        ///<summary>
        /// Get or Set the InvoiceContext Property of SystemWorkOrder
        /// InvoiceContext is Not Nullable
        ///</summary>


        [DisplayName("Invoice Context")]
        public bool InvoiceContext { get; set; }

        ///<summary>
        /// Get or Set the IsBillingWorkOrder Property of SystemWorkOrder
        /// IsBillingWorkOrder is Not Nullable
        ///</summary>


        [DisplayName("Is Billing Work Order")]
        public bool IsBillingWorkOrder { get; set; }

        [DisplayName("Is Discount Applicable")]
        public bool IsDiscountApplicable { get; set; }

        ///<summary>
        /// Get or Set the IsExternalOnly Property of SystemWorkOrder
        /// IsExternalOnly is Not Nullable
        ///</summary>


        [DisplayName("Is External Only")]
        public bool IsExternalOnly { get; set; }

        ///<summary>
        /// Get or Set the SystemLegacyActivityType Property of SystemWorkOrder
        /// SystemLegacyActivityType is Nullable 
        ///</summary>
        
        [StringLength(150)]
        [DisplayName("System Legacy Activity Type")]
        public string SystemLegacyActivityType { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the AllowThirdPartyInvoice Property of SystemWorkOrder
        /// AllowThirdPartyInvoice is Not Nullable
        ///</summary>


        [DisplayName("Allow Third Party Invoice")]
        public bool AllowThirdPartyInvoice { get; set; }
        ///<summary>
        /// Get or Set the IsRequestedBy Property of SystemWorkOrder
        /// IsRequestedBy is Not Nullable
        ///</summary>


        [DisplayName("Is Requested By")]
        public bool IsRequestedBy { get; set; }

        [DisplayName("Is Compliance Check Required")]
        public bool IsComplianceCheckRequired { get; set; }

        [DisplayName("Is Sanctions Check Required")]
        public bool IsSanctionsCheckRequired { get; set; }

        #endregion
    }
}
