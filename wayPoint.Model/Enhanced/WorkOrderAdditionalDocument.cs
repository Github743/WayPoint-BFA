using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderAdditionalDocument : BaseModel
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
        /// Get or Set the Id property of WorkOrderAdditionalDocument
        ///</summary>
        public int Id { get { return WorkOrderAdditionalDocumentId; } set { WorkOrderAdditionalDocumentId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderAdditionalDocumentId Property of WorkOrderAdditionalDocument
        /// WorkOrderAdditionalDocumentId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Additional Document Id")]
        public int WorkOrderAdditionalDocumentId { get; set; }

        ///<summary>
        /// Get or Set the Stream_Id Property of WorkOrderAdditionalDocument
        /// Stream_Id is Nullable 
        ///</summary>


        [DisplayName("Stream _ Id")]
        public Guid? Stream_Id { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderAdditionalDocument
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of WorkOrderAdditionalDocument
        /// Name is Not Nullable
        ///</summary>
        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the Description Property of WorkOrderAdditionalDocument
        /// Description is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Description")]
        public string Description { get; set; }

        ///<summary>
        /// Get or Set the InternalOnly Property of WorkOrderAdditionalDocument
        /// InternalOnly is Not Nullable
        ///</summary>


        [DisplayName("Internal Only")]
        public bool InternalOnly { get; set; }

        ///<summary>
        /// Get or Set the DocumentTypeId Property of WorkOrderAdditionalDocument
        /// DocumentTypeId is Nullable 
        ///</summary>


        [DisplayName("Document Type Id")]
        public int? DocumentTypeId { get; set; }

        ///<summary>
        /// Get or Set the FileName Property of WorkOrderAdditionalDocument
        /// FileName is Nullable 
        ///</summary>

        [StringLength(255)]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        ///<summary>
        /// Get or Set the FileType Property of WorkOrderAdditionalDocument
        /// FileType is Nullable 
        ///</summary>

        [StringLength(255)]
        [DisplayName("File Type")]
        public string FileType { get; set; }

        #endregion
    }
}
