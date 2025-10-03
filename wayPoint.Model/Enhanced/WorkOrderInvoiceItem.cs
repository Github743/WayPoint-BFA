using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class WorkOrderInvoiceItem
    {
        ///<summary>
        /// Get or Set the WorkOrderId Property of SystemProduct
        /// Amount is Not Nullable
        ///</summary>
        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the Amount Property of SystemProduct
        /// Amount is Not Nullable
        ///</summary>

        ///<summary>
        /// Get or Set the Name Property of SystemProduct
        /// Name is Not Nullable
        ///</summary>
        [Required]
        [StringLength(150)]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        public int WorkOrderItemEntityId { get; set; }

        /// <summary>
        /// Get or Set Is Price Optional property
        /// </summary>
        public bool IsPriceOptional { get; set; }
        public bool CanEdit { get; set; }
        public int PaySequence { get; set; }

        public bool DisplayOnInvoice { get; set; }
    }
}
