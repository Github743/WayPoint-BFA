using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselInspectionMonitoring : BaseModel
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
        /// Get or Set the Id property of VesselInspectionMonitoring
        ///</summary>
        public int Id { get { return VesselInspectionMonitoringId; } set { VesselInspectionMonitoringId = value; } }

        ///<summary>
        /// Get or Set the VesselInspectionMonitoringId Property of VesselInspectionMonitoring
        /// VesselInspectionMonitoringId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Inspection Monitoring Id")]
        public int VesselInspectionMonitoringId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of VesselInspectionMonitoring
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the IsBiAnnual Property of VesselInspectionMonitoring
        /// IsBiAnnual is Not Nullable
        ///</summary>


        [DisplayName("Is Bi Annual")]
        public bool IsBiAnnual { get; set; }

        ///<summary>
        /// Get or Set the ValidToDate Property of VesselInspectionMonitoring
        /// ValidToDate is Nullable 
        ///</summary>


        [DisplayName("Valid To Date")]
        public DateTime? ValidToDate { get; set; }

        ///<summary>
        /// Get or Set the IsSpecialMonitoring Property of VesselInspectionMonitoring
        /// IsSpecialMonitoring is Nullable 
        ///</summary>


        [DisplayName("Is Special Monitoring")]
        public bool IsSpecialMonitoring { get; set; }

        ///<summary>
        /// Get or Set the Note Property of VesselInspectionMonitoring
        /// Note is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Note")]
        public string Note { get; set; }

        public bool IsRegulatory { get; set; }

        ///<summary>
        /// Get or Set the DurationInMonth Property of VesselInspectionMonitoring
        /// DurationInMonth is Not Nullable
        ///</summary>


        [DisplayName("Duration In Month")]
        public int? DurationInMonth { get; set; }

        ///<summary>
        /// Get or Set the DetentionDate Property of VesselInspectionMonitoring
        /// DetentionDate is Nullable 
        ///</summary>


        [DisplayName("Detention Date")]
        public DateTime? DetentionDate { get; set; }

        ///<summary>
        /// Get or Set the ProgramType Property of VesselInspectionMonitoring
        /// ProgramType is Not Nullable
        ///</summary>


        [DisplayName("Program Type")]
        public int? ProgramType { get; set; }
        #endregion
    }
}
