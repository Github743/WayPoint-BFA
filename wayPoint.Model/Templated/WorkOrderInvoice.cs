using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class WorkOrderInvoice:BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string? SchemaName
        {
            get
            {
                return "AC.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the WorkOrderInvoiceId Property of WorkOrderInvoice
        /// WorkOrderInvoiceId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Invoice Id")]
        public int WorkOrderInvoiceId { get; set; }

        ///<summary>
        /// Get or Set the BillToClientId Property of WorkOrderInvoice
        /// BillToClientId is Nullable 
        ///</summary>


        [DisplayName("Bill To Client Id")]
        public int? BillToClientId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderInvoice
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the InvoiceNumber Property of WorkOrderInvoice
        /// InvoiceNumber is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Invoice Number")]
        public string? InvoiceNumber { get; set; }

        ///<summary>
        /// Get or Set the Amount Property of WorkOrderInvoice
        /// Amount is Not Nullable
        ///</summary>


        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        ///<summary>
        /// Get or Set the Balance Property of WorkOrderInvoice
        /// Balance is Not Nullable
        ///</summary>


        [DisplayName("Balance")]
        public decimal Balance { get; set; }

        ///<summary>
        /// Get or Set the Discount Property of WorkOrderInvoice
        /// Discount is Not Nullable
        ///</summary>


        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        ///<summary>
        /// Get or Set the Posted Property of WorkOrderInvoice
        /// Posted is Not Nullable
        ///</summary>


        [DisplayName("Posted")]
        public bool Posted { get; set; }

        ///<summary>
        /// Get or Set the InvoiceReference Property of WorkOrderInvoice
        /// InvoiceReference is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Invoice Reference")]
        public string? InvoiceReference { get; set; }

        ///<summary>
        /// Get or Set the PurchaseOrderNumber Property of WorkOrderInvoice
        /// PurchaseOrderNumber is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Purchase Order Number")]
        public string? PurchaseOrderNumber { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of WorkOrderInvoice
        /// EntityId is Nullable 
        ///</summary>


        [DisplayName("Entity Id")]
        public int? EntityId { get; set; }

        ///<summary>
        /// Get or Set the PreparedBy Property of WorkOrderInvoice
        /// PreparedBy is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Prepared By")]
        public string? PreparedBy { get; set; }

        ///<summary>
        /// Get or Set the ApprovedBy Property of WorkOrderInvoice
        /// ApprovedBy is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Approved By")]
        public string? ApprovedBy { get; set; }

        ///<summary>
        /// Get or Set the BillingPrefixLine1 Property of WorkOrderInvoice
        /// BillingPrefixLine1 is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Billing Prefix Line 1")]
        public string? BillingPrefixLine1 { get; set; }

        ///<summary>
        /// Get or Set the BillingPrefixLine2 Property of WorkOrderInvoice
        /// BillingPrefixLine2 is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Billing Prefix Line 2")]
        public string? BillingPrefixLine2 { get; set; }

        ///<summary>
        /// Get or Set the BillingClientName Property of WorkOrderInvoice
        /// BillingClientName is Nullable 
        ///</summary>

        [StringLength(300)]
        [DisplayName("Billing Client Name")]
        public string? BillingClientName { get; set; }

        ///<summary>
        /// Get or Set the IssueDate Property of WorkOrderInvoice
        /// IssueDate is Nullable 
        ///</summary>


        [DisplayName("Issue Date")]
        public DateTime? IssueDate { get; set; }

        ///<summary>
        /// Get or Set the DueDate Property of WorkOrderInvoice
        /// DueDate is Nullable 
        ///</summary>


        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        ///<summary>
        /// Get or Set the ThirdPartyClientRole Property of WorkOrderInvoice
        /// ThirdPartyClientRole is Nullable 
        ///</summary>


        [DisplayName("Third Party Client Role")]
        public int? ThirdPartyClientRole { get; set; }

        ///<summary>
        /// Get or Set the AllowThirdPartyInvoice Property of WorkOrderInvoice
        /// AllowThirdPartyInvoice is Not Nullable
        ///</summary>


        [DisplayName("Allow Third Party Invoice")]
        public bool AllowThirdPartyInvoice { get; set; }

        #endregion
    }
}
