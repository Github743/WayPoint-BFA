using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class EntityEmail : BaseModel
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
        /// Get or Set the Id property of EntityEmail
        ///</summary>
        public int Id { get { return EntityEmailId; } set { EntityEmailId = value; } }

        ///<summary>
        /// Get or Set the EntityEmailId Property of EntityEmail
        /// EntityEmailId is Not Nullable
        ///</summary>


        [DisplayName("Entity Email Id")]
        public int EntityEmailId { get; set; }

        ///<summary>
        /// Get or Set the EmailType Property of EntityEmail
        /// EmailType is Not Nullable
        ///</summary>


        [DisplayName("Email Type")]
        public int EmailType { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of EntityEmail
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the EmailId Property of EntityEmail
        /// EmailId is Not Nullable
        ///</summary>


        [DisplayName("Email Id")]
        public int EmailId { get; set; }

        ///<summary>
        /// Get or Set the Preference Property of EntityEmail
        /// Preference is Nullable 
        ///</summary>


        [DisplayName("Preference")]
        public bool? Preference { get; set; }

        #endregion
    }
}
