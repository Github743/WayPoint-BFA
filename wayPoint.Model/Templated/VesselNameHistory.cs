using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselNameHistory : BaseModel
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
        /// Get or Set the Id property of VesselNameHistory
        ///</summary>
        public int Id { get { return VesselNameHistoryId; } set { VesselNameHistoryId = value; } }

        ///<summary>
        /// Get or Set the VesselNameHistoryId Property of VesselNameHistory
        /// VesselNameHistoryId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Name History Id")]
        public int VesselNameHistoryId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of VesselNameHistory
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the FormerName Property of VesselNameHistory
        /// FormerName is Not Nullable
        ///</summary>
        [Required]
        [StringLength(300)]
        [DisplayName("Former Name")]
        public string FormerName { get; set; }

        ///<summary>
        /// Get or Set the EffectiveDate Property of VesselNameHistory
        /// EffectiveDate is Not Nullable
        ///</summary>


        [DisplayName("Effective Date")]
        public DateTime EffectiveDate { get; set; }

        ///<summary>
        /// Get or Set the LegacyId Property of VesselNameHistory
        /// LegacyId is Nullable 
        ///</summary>


        [DisplayName("Legacy Id")]
        public int? LegacyId { get; set; }

        #endregion
    }
}
