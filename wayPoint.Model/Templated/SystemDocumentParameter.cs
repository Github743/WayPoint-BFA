using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.Templated
{
    public partial class SystemDocumentParameter : BaseModel
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
        /// Get or Set the Id property of SystemDocumentParameter
        ///</summary>
        public int Id { get { return SystemDocumentParameterId; } set { SystemDocumentParameterId = value; } }

        ///<summary>
        /// Get or Set the SystemDocumentParameterId Property of SystemDocumentParameter
        /// SystemDocumentParameterId is Not Nullable
        ///</summary>


        [DisplayName("System Document Parameter Id")]
        public int SystemDocumentParameterId { get; set; }

        ///<summary>
        /// Get or Set the SystemDocumentId Property of SystemDocumentParameter
        /// SystemDocumentId is Nullable 
        ///</summary>


        [DisplayName("System Document Id")]
        public int? SystemDocumentId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of SystemDocumentParameter
        /// Name is Not Nullable
        ///</summary>
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the Description Property of SystemDocumentParameter
        /// Description is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        #endregion
    }
}
