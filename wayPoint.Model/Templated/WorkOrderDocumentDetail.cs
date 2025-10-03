using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderDocumentDetail : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        } // end of schema name property 


        ///<summary>
        /// Get or Set the WorkOrderDocumentId Property of WorkOrderDocumentDetail
        /// WorkOrderDocumentId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Document Id")]
        public int WorkOrderDocumentId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of WorkOrderDocumentDetail
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemId Property of WorkOrderDocumentDetail
        /// WorkOrderItemId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Id")]
        public int WorkOrderItemId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderDocumentDetail
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderEntityId Property of WorkOrderDocumentDetail
        /// WorkOrderEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        ///<summary>
        /// Get or Set the ClientId Property of WorkOrderDocumentDetail
        /// ClientId is Nullable 
        ///</summary>


        [DisplayName("Client Id")]
        public int? ClientId { get; set; }

        ///<summary>
        /// Get or Set the ClientName Property of WorkOrderDocumentDetail
        /// ClientName is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        ///<summary>
        /// Get or Set the IMONumber Property of WorkOrderDocumentDetail
        /// IMONumber is Nullable 
        ///</summary>


        [DisplayName("IMO Number")]
        public int? IMONumber { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderItemName Property of WorkOrderDocumentDetail
        /// SystemWorkOrderItemName is Not Nullable
        ///</summary>
        [Required]
        [StringLength(150)]
        [DisplayName("System Work Order Item Name")]
        public string SystemWorkOrderItemName { get; set; }

        ///<summary>
        /// Get or Set the SystemDocumentId Property of WorkOrderDocumentDetail
        /// SystemDocumentId is Not Nullable
        ///</summary>


        [DisplayName("System Document Id")]
        public int SystemDocumentId { get; set; }

        ///<summary>
        /// Get or Set the TrackingId Property of WorkOrderDocumentDetail
        /// TrackingId is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Tracking Id")]
        public string TrackingId { get; set; }

        ///<summary>
        /// Get or Set the IsDraft Property of WorkOrderDocumentDetail
        /// IsDraft is Not Nullable
        ///</summary>


        [DisplayName("Is Draft")]
        public bool IsDraft { get; set; }

        ///<summary>
        /// Get or Set the DocumentDraftFlag Property of WorkOrderDocumentDetail
        /// DocumentDraftFlag is Not Nullable
        ///</summary>


        [DisplayName("Document Draft Flag")]
        public bool DocumentDraftFlag { get; set; }

        ///<summary>
        /// Get or Set the CanRegenerate Property of WorkOrderDocumentDetail
        /// CanRegenerate is Not Nullable
        ///</summary>


        [DisplayName("Can Regenerate")]
        public bool CanRegenerate { get; set; }

        ///<summary>
        /// Get or Set the Name Property of WorkOrderDocumentDetail
        /// Name is Not Nullable
        ///</summary>
        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the DisplayName Property of WorkOrderDocumentDetail
        /// DisplayName is Not Nullable
        ///</summary>
        [Required]
        [StringLength(173)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        ///<summary>
        /// Get or Set the OutputFormat Property of WorkOrderDocumentDetail
        /// OutputFormat is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Output Format")]
        public string OutputFormat { get; set; }

        ///<summary>
        /// Get or Set the FromClient Property of WorkOrderDocumentDetail
        /// FromClient is Not Nullable
        ///</summary>


        [DisplayName("From Client")]
        public bool FromClient { get; set; }

        ///<summary>
        /// Get or Set the CanShow Property of WorkOrderDocumentDetail
        /// CanShow is Not Nullable
        ///</summary>


        [DisplayName("Can Show")]
        public bool CanShow { get; set; }

        ///<summary>
        /// Get or Set the ReportFileName Property of WorkOrderDocumentDetail
        /// ReportFileName is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Report File Name")]
        public string ReportFileName { get; set; }

        ///<summary>
        /// Get or Set the CanExternalUploadOrDelete Property of WorkOrderDocumentDetail
        /// CanExternalUploadOrDelete is Not Nullable
        ///</summary>


        [DisplayName("Can External Upload Or Delete")]
        public bool CanExternalUploadOrDelete { get; set; }

        ///<summary>
        /// Get or Set the IsOutgoing Property of WorkOrderDocumentDetail
        /// IsOutgoing is Not Nullable
        ///</summary>


        [DisplayName("Is Outgoing")]
        public bool IsOutgoing { get; set; }

        ///<summary>
        /// Get or Set the IsRequired Property of WorkOrderDocumentDetail
        /// IsRequired is Not Nullable
        ///</summary>


        [DisplayName("Is Required")]
        public bool IsRequired { get; set; }

        ///<summary>
        /// Get or Set the Reviewed Property of WorkOrderDocumentDetail
        /// Reviewed is Not Nullable
        ///</summary>


        [DisplayName("Reviewed")]
        public bool Reviewed { get; set; }

        ///<summary>
        /// Get or Set the Approved Property of WorkOrderDocumentDetail
        /// Approved is Not Nullable
        ///</summary>


        [DisplayName("Approved")]
        public bool Approved { get; set; }

        ///<summary>
        /// Get or Set the IsActive Property of WorkOrderDocumentDetail
        /// IsActive is Not Nullable
        ///</summary>


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        ///<summary>
        /// Get or Set the GenerationDate Property of WorkOrderDocumentDetail
        /// GenerationDate is Nullable 
        ///</summary>


        [DisplayName("Generation Date")]
        public DateTime? GenerationDate { get; set; }

        ///<summary>
        /// Get or Set the IssueDate Property of WorkOrderDocumentDetail
        /// IssueDate is Nullable 
        ///</summary>


        [DisplayName("Issue Date")]
        public DateTime? IssueDate { get; set; }

        ///<summary>
        /// Get or Set the HangfireJobId Property of WorkOrderDocumentDetail
        /// HangfireJobId is Nullable 
        ///</summary>


        [DisplayName("Hangfire Job Id")]
        public int? HangfireJobId { get; set; }

        ///<summary>
        /// Get or Set the QRCodeStreamId Property of WorkOrderDocumentDetail
        /// QRCodeStreamId is Nullable 
        ///</summary>


        [DisplayName("QR Code Stream Id")]
        public Guid? QRCodeStreamId { get; set; }

        ///<summary>
        /// Get or Set the VerificationURL Property of WorkOrderDocumentDetail
        /// VerificationURL is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Verification URL")]
        public string VerificationURL { get; set; }

        ///<summary>
        /// Get or Set the DocumentDated Property of WorkOrderDocumentDetail
        /// DocumentDated is Not Nullable
        ///</summary>


        [DisplayName("Document Dated")]
        public DateTime DocumentDated { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderName Property of WorkOrderDocumentDetail
        /// WorkOrderName is Not Nullable
        ///</summary>
        [Required]
        [StringLength(100)]
        [DisplayName("Work Order Name")]
        public string WorkOrderName { get; set; }

        ///<summary>
        /// Get or Set the ShowReviewedFlag Property of WorkOrderDocumentDetail
        /// ShowReviewedFlag is Not Nullable
        ///</summary>


        [DisplayName("Show Reviewed Flag")]
        public bool ShowReviewedFlag { get; set; }

        ///<summary>
        /// Get or Set the WoCreationDate Property of WorkOrderDocumentDetail
        /// WoCreationDate is Not Nullable
        ///</summary>


        [DisplayName("Wo Creation Date")]
        public DateTime WoCreationDate { get; set; }

        ///<summary>
        /// Get or Set the WoCreatedBy Property of WorkOrderDocumentDetail
        /// WoCreatedBy is Not Nullable
        ///</summary>
        [Required]
        [StringLength(36)]
        [DisplayName("Wo Created By")]
        public string WoCreatedBy { get; set; }

        ///<summary>
        /// Get or Set the HasNotes Property of WorkOrderDocumentDetail
        /// HasNotes is Not Nullable
        ///</summary>


        [DisplayName("Has Notes")]
        public bool HasNotes { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderDocumentNoteId Property of WorkOrderDocumentDetail
        /// WorkOrderDocumentNoteId is Nullable 
        ///</summary>


        [DisplayName("Work Order Document Note Id")]
        public int? WorkOrderDocumentNoteId { get; set; }

        ///<summary>
        /// Get or Set the WorkOderDocumentNote Property of WorkOrderDocumentDetail
        /// WorkOderDocumentNote is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Work Oder Document Note")]
        public string WorkOderDocumentNote { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderDocumentId Property of WorkOrderDocumentDetail
        /// SystemWorkOrderDocumentId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Document Id")]
        public int SystemWorkOrderDocumentId { get; set; }

        ///<summary>
        /// Get or Set the AcceptableCopy Property of WorkOrderDocumentDetail
        /// AcceptableCopy is Not Nullable
        ///</summary>


        [DisplayName("Acceptable Copy")]
        public bool AcceptableCopy { get; set; }

        ///<summary>
        /// Get or Set the OriginalInLocalOffice Property of WorkOrderDocumentDetail
        /// OriginalInLocalOffice is Not Nullable
        ///</summary>


        [DisplayName("Original In Local Office")]
        public bool OriginalInLocalOffice { get; set; }

        ///<summary>
        /// Get or Set the OriginalInNY Property of WorkOrderDocumentDetail
        /// OriginalInNY is Not Nullable
        ///</summary>


        [DisplayName("Original In NY")]
        public bool OriginalInNY { get; set; }

        ///<summary>
        /// Get or Set the Skipped Property of WorkOrderDocumentDetail
        /// Skipped is Not Nullable
        ///</summary>


        [DisplayName("Skipped")]
        public bool Skipped { get; set; }

        ///<summary>
        /// Get or Set the ActionTakenBy Property of WorkOrderDocumentDetail
        /// ActionTakenBy is Nullable 
        ///</summary>

        [StringLength(36)]
        [DisplayName("Action Taken By")]
        public string ActionTakenBy { get; set; }

        ///<summary>
        /// Get or Set the CanUndated Property of WorkOrderDocumentDetail
        /// CanUndated is Not Nullable
        ///</summary>


        [DisplayName("Can Undated")]
        public bool CanUndated { get; set; }

        ///<summary>
        /// Get or Set the CertificateStatus Property of WorkOrderDocumentDetail
        /// CertificateStatus is Nullable 
        ///</summary>


        [DisplayName("Certificate Status")]
        public int? CertificateStatus { get; set; }

        ///<summary>
        /// Get or Set the CertificateStatusName Property of WorkOrderDocumentDetail
        /// CertificateStatusName is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Certificate Status Name")]
        public string CertificateStatusName { get; set; }

        ///<summary>
        /// Get or Set the IsRegistrationWorkOrder Property of WorkOrderDocumentDetail
        /// IsRegistrationWorkOrder is Nullable 
        ///</summary>

        [DisplayName("Is Registration Work Order")]
        public bool IsRegistrationWorkOrder { get; set; }

        ///<summary>
        /// Get or Set the IsPostClosing Property of WorkOrderDocumentDetail
        /// IsPostClosing is Nullable 
        ///</summary>

        [DisplayName("Is Post Closing")]
        public bool IsPostClosing { get; set; }

        ///<summary>
        /// Get or Set the IsBackupCopy Property of WorkOrderDocumentDetail
        /// IsBackupCopy is Nullable 
        ///</summary>

        [DisplayName("Is Backup Copy")]
        public bool IsBackupCopy { get; set; }

        ///<summary>
        /// Get or Set the IsDraftCopy Property of WorkOrderDocumentDetail
        /// IsDraftCopy is Nullable 
        ///</summary>

        [DisplayName("Is Draft Copy")]
        public bool IsDraftCopy { get; set; }

        ///<summary>
        /// Get or Set the IsMerge Property of WorkOrderDocumentDetail
        /// IsMerge is Nullable 
        ///</summary>

        [DisplayName("Is Merge")]
        public bool IsMerge { get; set; }

        /// <summary>
        /// Get or Set the DefaultOrder Property of WorkOrderDocumentDetail
        /// DefaultOrder is Nullable
        /// </summary>
        [DisplayName("Default Order")]
        public int? DefaultOrder { get; set; }


        [DisplayName("Is CleanDoc")]
        public bool IsCleanDoc { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderStatus Property of WorkOrderDocumentDetail
        /// WorkOrderStatus is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Work Order Status")]
        public string WorkOrderStatus { get; set; }
        [DisplayName("IsInternal")]
        public bool IsInternal { get; set; }

        public bool? HasAttachment { get; set; }

        public bool VesselContext { get; set; }

        public bool AllowBulkActivity { get; set; }

        [DisplayName("Is Watermark")]
        public bool IsWatermark { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        [DisplayName("File Type")]
        public string FileType { get; set; }

        [DisplayName("QRCode File Name")]
        public string QRCodeFileName { get; set; }


        [DisplayName("Is Client Sanctioned")]
        public bool? IsClientSanctioned { get; set; }


        [DisplayName("Is Vessel Sanctioned")]
        public bool? IsVesselSanctioned { get; set; }

        #endregion
    }
}

