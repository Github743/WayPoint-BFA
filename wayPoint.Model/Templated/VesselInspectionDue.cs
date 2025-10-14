using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.Templated
{
    public partial class VesselInspectionDue : BaseModel
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
        /// Get or Set the Id property of VesselInspectionDue
        ///</summary>
        public int Id { get { return VesselInspectionDueId; } set { VesselInspectionDueId = value; } }

        ///<summary>
        /// Get or Set the VesselInspectionDueId Property of VesselInspectionDue
        /// VesselInspectionDueId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Inspection Due Id")]
        public int VesselInspectionDueId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of VesselInspectionDue
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the ASIDueDate Property of VesselInspectionDue
        /// ASIDueDate is Not Nullable
        ///</summary>


        [DisplayName("ASI Due Date")]
        public DateTime ASIDueDate { get; set; }

        ///<summary>
        /// Get or Set the BiAnnualDueDate Property of VesselInspectionDue
        /// BiAnnualDueDate is Nullable 
        ///</summary>


        [DisplayName("Bi Annual Due Date")]
        public DateTime? BiAnnualDueDate { get; set; }

        ///<summary>
        /// Get or Set the QuarterlyDueDate Property of VesselInspectionDue
        /// QuarterlyDueDate is Nullable 
        ///</summary>


        [DisplayName("Quarterly Due Date")]
        public DateTime? QuarterlyDueDate { get; set; }

        ///<summary>
        /// Get or Set the SpecialMonitoringDueDate Property of VesselInspectionDue
        /// SpecialMonitoringDueDate is Nullable 
        ///</summary>


        [DisplayName("Special Monitoring Due Date")]
        public DateTime? SpecialMonitoringDueDate { get; set; }

        #endregion
    }
}
