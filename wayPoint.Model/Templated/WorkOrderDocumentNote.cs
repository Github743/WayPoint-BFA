using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderDocumentNote : BaseModel
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
        /// Get or Set the Id property of WorkOrderDocumentNote
        ///</summary>
        public  int Id { get { return WorkOrderDocumentNoteId; } set { WorkOrderDocumentNoteId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderDocumentNoteId Property of WorkOrderDocumentNote
        /// WorkOrderDocumentNoteId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Document Note Id")]
        public int WorkOrderDocumentNoteId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderDocumentId Property of WorkOrderDocumentNote
        /// WorkOrderDocumentId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Document Id")]
        public int WorkOrderDocumentId { get; set; }

        ///<summary>
        /// Get or Set the NoteId Property of WorkOrderDocumentNote
        /// NoteId is Not Nullable
        ///</summary>


        [DisplayName("Note Id")]
        public int NoteId { get; set; }

        ///<summary>
        /// Get or Set the IsInternal Property of WorkOrderDocumentNote
        /// IsInternal is Not Nullable
        ///</summary>


        [DisplayName("Is Internal")]
        public bool IsInternal { get; set; }

        #endregion
    }
}
