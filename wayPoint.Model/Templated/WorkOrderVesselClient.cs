using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    [Table("WorkOrderVesselClient", Schema = "WO")]
    public partial class WorkOrderVesselClient : BaseModel
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
        /// Get or Set the Id property of WorkOrderVesselClient
        ///</summary>
        [NotMapped]
        public int Id { get { return WorkOrderVesselClientId; } set { WorkOrderVesselClientId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderVesselClientId Property of WorkOrderVesselClient
        /// WorkOrderVesselClientId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Vessel Client Id")]
        public int WorkOrderVesselClientId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderVesselId Property of WorkOrderVesselClient
        /// WorkOrderVesselId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Vessel Id")]
        public int WorkOrderVesselId { get; set; }

        ///<summary>
        /// Get or Set the ClientRoleId Property of WorkOrderVesselClient
        /// ClientRoleId is Not Nullable
        ///</summary>


        [DisplayName("Client Role Id")]
        public int ClientRoleId { get; set; }

        ///<summary>
        /// Get or Set the VesselClientId Property of WorkOrderVesselClient
        /// VesselClientId is Nullable 
        ///</summary>


        [DisplayName("Vessel Client Id")]
        public int? VesselClientId { get; set; }

        [DisplayName("IsNew")]
        public bool IsNew { get; set; }

        [DisplayName("IsRemoved")]
        public bool IsRemoved { get; set; }
        [NotMapped]
        [DisplayName("IsClientSanctioned")]
        public bool IsClientSanctioned { get; set; }

        #endregion
    }
}
