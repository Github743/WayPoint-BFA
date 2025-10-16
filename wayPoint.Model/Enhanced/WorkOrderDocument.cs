using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderDocument
    {
        /// <summary>
        /// Get or set the Work order item id property of Work Order Document
        /// </summary>
        [DisplayName("Work Order Item Id")]
        public int WorkOrderItemId { get; set; }

        /// <summary>
        /// Get or Set Work Order Id Property of Work Order Document
        /// </summary>
        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        /// <summary>
        /// Get or Set Work Order Entity Id Property of Work Order Document
        /// </summary>
        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        /// <summary>
        /// Get or Set System Work Order Item Name Property of Work Order Document
        /// </summary>
        [StringLength(150)]
        [DisplayName("System Work Order Item Name")]
        public string SystemWorkOrderItemName { get; set; }

        /// <summary>
        /// Get or Set Name Property of Work Order Document 
        /// </summary>
        [StringLength(150)]
        [DisplayName("Document Name")]
        public string Name { get; set; }

        /// <summary>
        /// Get or Set Display Name Property of Work Order Document
        /// </summary>
        [StringLength(150)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or Set the Output Format Property of Work Order Document 
        /// </summary>
        [StringLength(50)]
        [DisplayName("Output Format")]
        public string OutputFormat { get; set; }

        /// <summary>
        /// Get or Set the From Client Property of Work Order Document 
        /// </summary>
        [DisplayName("From Client Flag")]
        public bool FromClient { get; set; }

        /// <summary>
        /// Get or Set the Report File Name Property of Work Order Document
        /// </summary>
        [StringLength(100)]
        [DisplayName("Report File Name")]
        public string ReportFileName { get; set; }

        /// <summary>
        /// Get or Set the Is Outgoing Property of Work Order Document 
        /// </summary>
        public bool IsOutgoing { get; set; }

        /// <summary>
        /// Get or Set the Is Required Property of Work Order Document
        /// </summary>
        public bool IsRequired { get; set; }
        //public string WorkOrderDocumentNote { get; set; }

        public bool ConsiderConfirmation { get; set; }

        public bool HasBusinessLogic { get; set; }
        public bool IsRegistrationWorkOrder { get; set; }
        public string ReportTypeName { get; set; }

        public bool CanUndated { get; set; }

        public string WorkOrderName { get; set; }

        public bool IsMerge { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public bool IsInternal { get; set; }
        public bool AllowBulkActivity { get; set; }
        public bool IsCustomReGenerate { get; set; }
        public bool IsBackupCopy { get; set; }
        public int? DocumentQRCodeId { get; set; }
        public bool ShowOnCertPage { get; set; }
        public bool IsInvoice { get; set; }
    }
}
