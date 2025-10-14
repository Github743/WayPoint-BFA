using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselContact : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "VS.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of VesselContact
        ///</summary>
        public int Id { get { return VesselContactId; } set { VesselContactId = value; } }

        ///<summary>
        /// Get or Set the VesselContactId Property of VesselContact
        /// VesselContactId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Contact Id")]
        public int VesselContactId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of VesselContact
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the ContactRoleId Property of VesselContact
        /// ContactRoleId is Not Nullable
        ///</summary>


        [DisplayName("Contact Role Id")]
        public int ContactRoleId { get; set; }

        ///<summary>
        /// Get or Set the FromDate Property of VesselContact
        /// FromDate is Not Nullable
        ///</summary>


        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        ///<summary>
        /// Get or Set the ToDate Property of VesselContact
        /// ToDate is Nullable 
        ///</summary>


        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        ///<summary>
        /// Get or Set the LegacyId Property of VesselContact
        /// LegacyId is Nullable 
        ///</summary>


        [DisplayName("Legacy Id")]
        public int? LegacyId { get; set; }

        #endregion
    }
}
