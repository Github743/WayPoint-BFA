using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderInvoiceItem : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "AC.usp_";
            }
        } // end of schema name property         

        ///<summary>
        /// Get or Set the WorkOrderInvoiceItemId Property of WorkOrderInvoiceItem
        /// WorkOrderInvoiceItemId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Invoice Item Id")]
        public int WorkOrderInvoiceItemId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderInvoiceId Property of WorkOrderInvoiceItem
        /// WorkOrderInvoiceId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Invoice Id")]
        public int WorkOrderInvoiceId { get; set; }

        ///<summary>
        /// Get or Set the SystemProductId Property of WorkOrderInvoiceItem
        /// SystemProductId is Not Nullable
        ///</summary>


        [DisplayName("System Product Id")]
        public int SystemProductId { get; set; }

        ///<summary>
        /// Get or Set the Amount Property of WorkOrderInvoiceItem
        /// Amount is Not Nullable
        ///</summary>


        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        ///<summary>
        /// Get or Set the Balance Property of WorkOrderInvoiceItem
        /// Balance is Not Nullable
        ///</summary>


        [DisplayName("Balance")]
        public decimal Balance { get; set; }

        ///<summary>
        /// Get or Set the Discount Property of WorkOrderInvoiceItem
        /// Discount is Not Nullable
        ///</summary>


        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        ///<summary>
        /// Get or Set the Quantity Property of WorkOrderInvoiceItem
        /// Quantity is Nullable 
        ///</summary>


        [DisplayName("Quantity")]
        public int? Quantity { get; set; }

        ///<summary>
        /// Get or Set the DefinedDiscount Property of WorkOrderInvoiceItem
        /// DefinedDiscount is Not Nullable
        ///</summary>


        [DisplayName("Defined Discount")]
        public bool DefinedDiscount { get; set; }

        ///<summary>
        /// Get or Set the IsCustomProduct Property of WorkOrderInvoiceItem
        /// IsCustomProduct is Not Nullable
        ///</summary>


        [DisplayName("Is Custom Product")]
        public bool IsCustomProduct { get; set; }

        #endregion
    }
}
