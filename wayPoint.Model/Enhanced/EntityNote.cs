using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class EntityNote
    {
        ///<summary>
        /// Get or Set the Note Property of Note
        /// Note is Not Nullable
        ///</summary>
        [Required]
        [StringLength(4096)]
        [DisplayName("Note")]
        public string Text { get; set; }
        ///<summary>
        /// Get or Set the Name Property of LookupType
        /// Name is Not Nullable
        ///</summary>       
        [StringLength(150)]
        [DisplayName("NoteTypeLookupName")]
        public string NoteTypeLookupName { get; set; }


        [StringLength(150)]
        [DisplayName("NoteSubTypeLookupName")]
        public string NoteSubTypeLookupName { get; set; }


        [StringLength(150)]
        [DisplayName("NoteTypeLookupTypeName")]
        public string NoteTypeLookupTypeName { get; set; }


        [StringLength(150)]
        [DisplayName("NoteSubTypeLookupTypeName")]
        public string NoteSubTypeLookupTypeName { get; set; }

        [DisplayName("ProrityTypeLookupName")]
        public string ProrityTypeLookupName { get; set; }

        [DisplayName("ProrityTypeLookupTypeName")]
        public string ProrityTypeLookupTypeName { get; set; }

        [DisplayName("Priority")]
        public int? ProrityType { get; set; }

        public string sDepartment { get; set; }

        public bool IsLisCommunication { get; set; }
    }
}
