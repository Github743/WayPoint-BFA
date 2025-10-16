using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class VesselOwner : BaseModel
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
        /// Get or Set the Id property of VesselOwner
        ///</summary>
        public int Id { get { return VesselOwnerId; } set { VesselOwnerId = value; } }

        ///<summary>
        /// Get or Set the VesselOwnerId Property of VesselOwner
        /// VesselOwnerId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Owner Id")]
        public int VesselOwnerId { get; set; }

        ///<summary>
        /// Get or Set the CorporateId Property of VesselOwner
        /// CorporateId is Nullable 
        ///</summary>


        [DisplayName("Corporate Id")]
        public int? CorporateId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of VesselOwner
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the EntityAddressId Property of VesselOwner
        /// EntityAddressId is Nullable 
        ///</summary>


        [DisplayName("Entity Address Id")]
        public int? EntityAddressId { get; set; }

        ///<summary>
        /// Get or Set the IsFME Property of VesselOwner
        /// IsFME is Nullable 
        ///</summary>


        [DisplayName("Is FME")]
        public bool? IsFME { get; set; }

        ///<summary>
        /// Get or Set the Citizenship Property of VesselOwner
        /// Citizenship is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Citizenship")]
        public string Citizenship { get; set; }

        ///<summary>
        /// Get or Set the Proportion Property of VesselOwner
        /// Proportion is Nullable 
        ///</summary>


        [DisplayName("Proportion")]
        public double? Proportion { get; set; }

        ///<summary>
        /// Get or Set the FromDate Property of VesselOwner
        /// FromDate is Not Nullable
        ///</summary>


        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        ///<summary>
        /// Get or Set the ToDate Property of VesselOwner
        /// ToDate is Nullable 
        ///</summary>


        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        ///<summary>
        /// Get or Set the VesselOwnerName Property of VesselOwner
        /// VesselOwnerName is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Vessel Owner Name")]
        public string VesselOwnerName { get; set; }

        ///<summary>
        /// Get or Set the CitizenCountry Property of VesselOwner
        /// CitizenCountry is Nullable 
        ///</summary>


        [DisplayName("Citizen Country")]
        public int? CitizenCountry { get; set; }

        ///<summary>
        /// Get or Set the Residence Property of VesselOwner
        /// Residence is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Residence")]
        public string Residence { get; set; }

        ///<summary>
        /// Get or Set the LegacyId Property of VesselOwner
        /// LegacyId is Nullable 
        ///</summary>


        [DisplayName("Legacy Id")]
        public int? LegacyId { get; set; }

        #endregion
    }
}

