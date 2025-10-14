using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderVesselOwner : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of WorkOrderVesselOwner
        ///</summary>
        public int Id { get { return WorkorderVesselOwnerId; } set { WorkorderVesselOwnerId = value; } }

        ///<summary>
        /// Get or Set the WorkorderVesselOwnerId Property of WorkOrderVesselOwner
        /// WorkorderVesselOwnerId is Not Nullable
        ///</summary>


        [DisplayName("Workorder Vessel Owner Id")]
        public int WorkorderVesselOwnerId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderVesselId Property of WorkOrderVesselOwner
        /// WorkOrderVesselId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Vessel Id")]
        public int WorkOrderVesselId { get; set; }

        ///<summary>
        /// Get or Set the CorporateId Property of WorkOrderVesselOwner
        /// CorporateId is Nullable 
        ///</summary>


        [DisplayName("Corporate Id")]
        public int? CorporateId { get; set; }

        ///<summary>
        /// Get or Set the EntityAddressId Property of WorkOrderVesselOwner
        /// EntityAddressId is Nullable 
        ///</summary>


        [DisplayName("Entity Address Id")]
        public int? EntityAddressId { get; set; }

        ///<summary>
        /// Get or Set the IsFME Property of WorkOrderVesselOwner
        /// IsFME is Nullable 
        ///</summary>


        [DisplayName("Is FME")]
        public bool? IsFME { get; set; }

        ///<summary>
        /// Get or Set the Citizenship Property of WorkOrderVesselOwner
        /// Citizenship is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Citizenship")]
        public string Citizenship { get; set; }

        ///<summary>
        /// Get or Set the Proportion Property of WorkOrderVesselOwner
        /// Proportion is Nullable 
        ///</summary>


        [DisplayName("Proportion")]
        public double? Proportion { get; set; }

        ///<summary>
        /// Get or Set the VesselOwnerName Property of WorkOrderVesselOwner
        /// VesselOwnerName is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Vessel Owner Name")]
        public string VesselOwnerName { get; set; }

        ///<summary>
        /// Get or Set the VesselOwnerId Property of WorkOrderVesselOwner
        /// VesselOwnerId is Nullable 
        ///</summary>


        [DisplayName("Vessel Owner Id")]
        public int? VesselOwnerId { get; set; }

        ///<summary>
        /// Get or Set the CitizenCountry Property of WorkOrderVesselOwner
        /// CitizenCountry is Nullable 
        ///</summary>


        [DisplayName("Citizen Country")]
        public int? CitizenCountry { get; set; }

        ///<summary>
        /// Get or Set the IsNew Property of WorkOrderVesselOwner
        /// IsNew is Not Nullable
        ///</summary>


        [DisplayName("Is New")]
        public bool IsNew { get; set; }

        ///<summary>
        /// Get or Set the IsDeletion Property of WorkOrderVesselOwner
        /// IsDeletion is Not Nullable
        ///</summary>


        [DisplayName("Is Deletion")]
        public bool IsDeletion { get; set; }

        ///<summary>
        /// Get or Set the Residence Property of WorkOrderVesselOwner
        /// Residence is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Residence")]
        public string Residence { get; set; }

        ///<summary>
        /// Get or Set the VerifiedBy Property of WorkOrderVesselOwner
        /// VerifiedBy is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Verified By")]
        public string VerifiedBy { get; set; }

        ///<summary>
        /// Get or Set the IsVerified Property of WorkOrderVesselOwner
        /// IsVerified is Not Nullable
        ///</summary>


        [DisplayName("Is Verified")]
        public bool IsVerified { get; set; }

        ///<summary>
        /// Get or Set the RegistrationNumber Property of WorkOrderVesselOwner
        /// RegistrationNumber is Nullable 
        ///</summary>


        [DisplayName("Registration Number")]
        public int? RegistrationNumber { get; set; }

        ///<summary>
        /// Get or Set the OwnerIMONumber Property of WorkOrderVesselOwner
        /// OwnerIMONumber is Nullable 
        ///</summary>


        [DisplayName("Owner IMO Number")]
        public int? OwnerIMONumber { get; set; }

        #endregion
    }
}
