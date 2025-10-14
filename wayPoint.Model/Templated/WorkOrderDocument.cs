using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    [Table("WorkOrderDocument", Schema = "WO")]
    public partial class WorkOrderDocument : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO.";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of WorkOrderDocument
        ///</summary>
        public int Id { get { return WorkOrderDocumentId; } set { WorkOrderDocumentId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderDocumentId Property of WorkOrderDocument
        /// WorkOrderDocumentId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Document Id")]
        public int WorkOrderDocumentId { get; set; }

        ///<summary>
        /// Get or Set the SystemDocumentId Property of WorkOrderDocument
        /// SystemDocumentId is Not Nullable
        ///</summary>


        [DisplayName("System Document Id")]
        public int SystemDocumentId { get; set; }

        ///<summary>
        /// Get or Set the Stream_Id Property of WorkOrderDocument
        /// Stream_Id is Nullable 
        ///</summary>


        [DisplayName("Stream _ Id")]
        public Guid? Stream_Id { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderDocument
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the TrackingId Property of WorkOrderDocument
        /// TrackingId is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Tracking Id")]
        public string TrackingId { get; set; }

        ///<summary>
        /// Get or Set the IsDraft Property of WorkOrderDocument
        /// IsDraft is Not Nullable
        ///</summary>


        [DisplayName("Is Draft")]
        public bool IsDraft { get; set; }

        ///<summary>
        /// Get or Set the CanRegenerate Property of WorkOrderDocument
        /// CanRegenerate is Not Nullable
        ///</summary>


        [DisplayName("Can Regenerate")]
        public bool CanRegenerate { get; set; }

        ///<summary>
        /// Get or Set the Reviewed Property of WorkOrderDocument
        /// Reviewed is Not Nullable
        ///</summary>


        [DisplayName("Reviewed")]
        public bool Reviewed { get; set; }

        ///<summary>
        /// Get or Set the Approved Property of WorkOrderDocument
        /// Approved is Not Nullable
        ///</summary>


        [DisplayName("Approved")]
        public bool Approved { get; set; }

        ///<summary>
        /// Get or Set the IsActive Property of WorkOrderDocument
        /// IsActive is Not Nullable
        ///</summary>


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        ///<summary>
        /// Get or Set the GenerationDate Property of WorkOrderDocument
        /// GenerationDate is Nullable 
        ///</summary>


        [DisplayName("Generation Date")]
        public DateTime? GenerationDate { get; set; }

        ///<summary>
        /// Get or Set the HangfireJobId Property of WorkOrderDocument
        /// HangfireJobId is Nullable 
        ///</summary>


        [DisplayName("Hangfire Job Id")]
        public int? HangfireJobId { get; set; }

        ///<summary>
        /// Get or Set the QRCodeStreamId Property of WorkOrderDocument
        /// QRCodeStreamId is Nullable 
        ///</summary>


        [DisplayName("QR Code Stream Id")]
        public Guid? QRCodeStreamId { get; set; }

        ///<summary>
        /// Get or Set the VerificationURL Property of WorkOrderDocument
        /// VerificationURL is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Verification URL")]
        public string VerificationURL { get; set; }

        ///<summary>
        /// Get or Set the Skipped Property of WorkOrderDocument
        /// Skipped is Not Nullable
        ///</summary>


        [DisplayName("Skipped")]
        public bool Skipped { get; set; }

        ///<summary>
        /// Get or Set the AcceptableCopy Property of WorkOrderDocument
        /// AcceptableCopy is Not Nullable
        ///</summary>


        [DisplayName("Acceptable Copy")]
        public bool AcceptableCopy { get; set; }

        ///<summary>
        /// Get or Set the OriginalInLocalOffice Property of WorkOrderDocument
        /// OriginalInLocalOffice is Not Nullable
        ///</summary>


        [DisplayName("Original In Local Office")]
        public bool OriginalInLocalOffice { get; set; }

        ///<summary>
        /// Get or Set the OriginalInNY Property of WorkOrderDocument
        /// OriginalInNY is Not Nullable
        ///</summary>


        [DisplayName("Original In MIA")]
        public bool OriginalInNY { get; set; }

        ///<summary>
        /// Get or Set the ActionTakenBy Property of WorkOrderDocument
        /// ActionTakenBy is Nullable 
        ///</summary>

        [StringLength(36)]
        [DisplayName("Action Taken By")]
        public string ActionTakenBy { get; set; }

        ///<summary>
        /// Get or Set the IsPostClosing Property of WorkOrderDocument
        /// IsPostClosing is Not Nullable
        ///</summary>


        [DisplayName("Is Post Closing")]
        public bool IsPostClosing { get; set; }


        [DisplayName("Is CleanDoc")]
        public bool IsCleanDoc { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        [DisplayName("File Type")]
        public string FileType { get; set; }

        [DisplayName("QRCode File Name")]
        public string QRCodeFileName { get; set; }

        #endregion
    }
}
