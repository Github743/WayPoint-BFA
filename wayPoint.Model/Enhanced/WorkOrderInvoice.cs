using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class WorkOrderInvoice
    {
        public string? ClientName { get; set; }

        /// <summary>
        /// Get or Set the Client Entity Id Property
        /// </summary>
        public int? ClientEntityId { get; set; }

        public int? WorkOrderId { get; set; }

        /// <summary>
        /// Get or Set the Entity Name Property
        /// </summary>
        public string? EntityName { get; set; }

        /// <summary>
        /// Get or Set the Official Number Property
        /// </summary>
        public int? OfficialNumber { get; set; }
        /// <summary>
        /// Get or Set the Vessel Id Property
        /// </summary>
        public int? VesselId { get; set; }

        /// <summary>
        /// Get or Set the Require Purchase Order Property
        /// </summary>
        public bool? RequirePurchaseOrder { get; set; }

        /// <summary>
        /// Get or Set the WorkOrder Vessel Name Property
        /// </summary>
        public string? WorkOrderVesselName { get; set; }

        /// <summary>
        /// Get or Set the WorkOrder Vessel  Official Number Property
        /// </summary>
        public int? WorkOrderVesselOfficialNo { get; set; }

        /// <summary>
        /// Get or Set the WorkOrder IMO Number Property
        /// </summary>
        public int? WorkOrderVesselIMO { get; set; }

        /// <summary>
        /// Get or Set the Billing Address Formatted Property
        /// </summary>
        public string? BillingAddressFormatted { get; set; }

        public int? NoteId { get; set; }

        [Required]
        [StringLength(4096)]
        [DisplayName("Note")]
        public string? Text { get; set; }

        public bool HasNotes { get; set; }
        public int? ClientNumber { get; set; }

        /// <summary>
        /// get or set Invoice File Name
        /// </summary>
        public string? InvoiceFileName { get; set; }
        public string? InterimOwnerName { get; set; }
        public int InterimOwnerType { get; set; }
        public string? InterimOwnerTypeName { get; set; }

        public bool? RequirePrePayment { get; set; }

    }
}
