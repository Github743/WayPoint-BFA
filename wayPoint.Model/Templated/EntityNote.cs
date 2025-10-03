using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class EntityNote : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "FN.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of EntityNote
        ///</summary>
        public int Id { get { return EntityNoteId; } set { EntityNoteId = value; } }

        ///<summary>
        /// Get or Set the EntityNoteId Property of EntityNote
        /// EntityNoteId is Not Nullable
        ///</summary>


        [DisplayName("Entity Note Id")]
        public int EntityNoteId { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of EntityNote
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the NoteId Property of EntityNote
        /// NoteId is Not Nullable
        ///</summary>


        [DisplayName("Note Id")]
        public int NoteId { get; set; }

        ///<summary>
        /// Get or Set the NoteSubType Property of EntityNote
        /// NoteSubType is Nullable 
        ///</summary>


        [DisplayName("Note Sub Type")]
        public int? NoteSubType { get; set; }

        ///<summary>
        /// Get or Set the NoteType Property of EntityNote
        /// NoteType is Not Nullable
        ///</summary>


        [DisplayName("Note Type")]
        public int NoteType { get; set; }

        ///<summary>
        /// Get or Set the ToDate Property of EntityNote
        /// ToDate is Nullable 
        ///</summary>


        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        ///<summary>
        /// Get or Set the FromDate Property of EntityNote
        /// FromDate is Nullable 
        ///</summary>


        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }

        ///<summary>
        /// Get or Set the LegacyId Property of EntityNote
        /// LegacyId is Nullable 
        ///</summary>


        [DisplayName("Legacy Id")]
        public int? LegacyId { get; set; }

        ///<summary>
        /// Get or Set the PriorityType Property of EntityNote
        /// PriorityType is Nullable 
        ///</summary>


        [DisplayName("Priority Type")]
        public int? PriorityType { get; set; }

        [DisplayName("Is Auto Created")]
        public bool IsAutoCreated { get; set; }
        #endregion
    }
}
