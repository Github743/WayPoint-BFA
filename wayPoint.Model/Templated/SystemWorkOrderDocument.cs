using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class SystemWorkOrderDocument : BaseModel
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
        /// Get or Set the Id property of SystemWorkOrderDocument
        ///</summary>
        public int Id { get { return SystemWorkOrderDocumentId; } set { SystemWorkOrderDocumentId = value; } }

        ///<summary>
        /// Get or Set the SystemWorkOrderDocumentId Property of SystemWorkOrderDocument
        /// SystemWorkOrderDocumentId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Document Id")]
        public int SystemWorkOrderDocumentId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderXrefItemId Property of SystemWorkOrderDocument
        /// SystemWorkOrderXrefItemId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Xref Item Id")]
        public int SystemWorkOrderXrefItemId { get; set; }

        ///<summary>
        /// Get or Set the SystemDocumentId Property of SystemWorkOrderDocument
        /// SystemDocumentId is Not Nullable
        ///</summary>


        [DisplayName("System Document Id")]
        public int SystemDocumentId { get; set; }

        ///<summary>
        /// Get or Set the HasBusinessLogic Property of SystemWorkOrderDocument
        /// HasBusinessLogic is Not Nullable
        ///</summary>


        [DisplayName("Has Business Logic")]
        public bool HasBusinessLogic { get; set; }

        ///<summary>
        /// Get or Set the IsOutgoing Property of SystemWorkOrderDocument
        /// IsOutgoing is Not Nullable
        ///</summary>


        [DisplayName("Is Outgoing")]
        public bool IsOutgoing { get; set; }

        ///<summary>
        /// Get or Set the IsRequired Property of SystemWorkOrderDocument
        /// IsRequired is Not Nullable
        ///</summary>


        [DisplayName("Is Required")]
        public bool IsRequired { get; set; }

        ///<summary>
        /// Get or Set the Skipped Property of SystemWorkOrderDocument
        /// Skipped is Not Nullable
        ///</summary>


        [DisplayName("Skipped")]
        public bool Skipped { get; set; }

        ///<summary>
        /// Get or Set the Reviewed Property of SystemWorkOrderDocument
        /// Reviewed is Not Nullable
        ///</summary>


        [DisplayName("Reviewed")]
        public bool Reviewed { get; set; }

        ///<summary>
        /// Get or Set the AcceptableCopy Property of SystemWorkOrderDocument
        /// AcceptableCopy is Not Nullable
        ///</summary>


        [DisplayName("Acceptable Copy")]
        public bool AcceptableCopy { get; set; }

        ///<summary>
        /// Get or Set the OriginalInLocalOffice Property of SystemWorkOrderDocument
        /// OriginalInLocalOffice is Not Nullable
        ///</summary>


        [DisplayName("Original In Local Office")]
        public bool OriginalInLocalOffice { get; set; }

        ///<summary>
        /// Get or Set the OriginalInNY Property of SystemWorkOrderDocument
        /// OriginalInNY is Not Nullable
        ///</summary>


        [DisplayName("Original In NY")]
        public bool OriginalInNY { get; set; }

        ///<summary>
        /// Get or Set the CanShowForExternal Property of SystemWorkOrderDocument
        /// CanShowForExternal is Not Nullable
        ///</summary>


        [DisplayName("Can Show For External")]
        public bool CanShowForExternal { get; set; }

        ///<summary>
        /// Get or Set the IsBackupCopy Property of SystemWorkOrderDocument
        /// IsBackupCopy is Not Nullable
        ///</summary>


        [DisplayName("Is Backup Copy")]
        public bool IsBackupCopy { get; set; }

        ///<summary>
        /// Get or Set the IsDraftCopy Property of SystemWorkOrderDocument
        /// IsDraftCopy is Not Nullable
        ///</summary>


        [DisplayName("Is Draft Copy")]
        public bool IsDraftCopy { get; set; }

        ///<summary>
        /// Get or Set the IsMerge Property of SystemWorkOrderDocument
        /// IsMerge is Not Nullable
        ///</summary>


        [DisplayName("Is Merge")]
        public bool IsMerge { get; set; }

        ///<summary>
        /// Get or Set the IsWatermark Property of SystemWorkOrderDocument
        /// IsWatermark is Not Nullable
        ///</summary>


        [DisplayName("Is Watermark")]
        public bool IsWatermark { get; set; }

        /// <summary>
        /// DefaultOrder is Nullable
        /// </summary>
        [DisplayName("Default Order")]
        public int? DefaultOrder { get; set; }

        #endregion
    }
}
