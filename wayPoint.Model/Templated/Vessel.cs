using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class Vessel : BaseModel
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
        /// Get or Set the Id property of Vessel
        ///</summary>
        public int Id { get { return VesselId; } set { VesselId = value; } }

        ///<summary>
        /// Get or Set the VesselId Property of Vessel
        /// VesselId is Not Nullable
        ///</summary>


        [DisplayName("Vessel Id")]
        public int VesselId { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of Vessel
        /// EntityId is Nullable 
        ///</summary>


        [DisplayName("Entity Id")]
        public int? EntityId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of Vessel
        /// Name is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the IMONumber Property of Vessel
        /// IMONumber is Nullable 
        ///</summary>


        [DisplayName("IMO Number")]
        public int? IMONumber { get; set; }

        ///<summary>
        /// Get or Set the OfficialNumber Property of Vessel
        /// OfficialNumber is Nullable 
        ///</summary>


        [DisplayName("Official Number")]
        public int? OfficialNumber { get; set; }

        ///<summary>
        /// Get or Set the CallSign Property of Vessel
        /// CallSign is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Call Sign")]
        public string CallSign { get; set; }

        ///<summary>
        /// Get or Set the Status Property of Vessel
        /// Status is Nullable 
        ///</summary>


        [DisplayName("Status")]
        public int? Status { get; set; }

        ///<summary>
        /// Get or Set the FlagState Property of Vessel
        /// FlagState is Not Nullable
        ///</summary>


        [DisplayName("Flag State")]
        public int FlagState { get; set; }

        ///<summary>
        /// Get or Set the VesselTypeId Property of Vessel
        /// VesselTypeId is Nullable 
        ///</summary>


        [DisplayName("Vessel Type Id")]
        public int? VesselTypeId { get; set; }

        ///<summary>
        /// Get or Set the Propulsion Property of Vessel
        /// Propulsion is Nullable 
        ///</summary>


        [DisplayName("Propulsion")]
        public int? Propulsion { get; set; }

        ///<summary>
        /// Get or Set the OriginalRegistrationDate Property of Vessel
        /// OriginalRegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Original Registration Date")]
        public DateTime? OriginalRegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the RegistrationDate Property of Vessel
        /// RegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Registration Date")]
        public DateTime? RegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the ReRegistrationDate Property of Vessel
        /// ReRegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Re Registration Date")]
        public DateTime? ReRegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the StrickenDate Property of Vessel
        /// StrickenDate is Nullable 
        ///</summary>


        [DisplayName("Stricken Date")]
        public DateTime? StrickenDate { get; set; }

        ///<summary>
        /// Get or Set the GrossTon Property of Vessel
        /// GrossTon is Nullable 
        ///</summary>


        [DisplayName("Gross Ton")]
        public double? GrossTon { get; set; }

        ///<summary>
        /// Get or Set the DualGrossTon Property of Vessel
        /// DualGrossTon is Nullable 
        ///</summary>


        [DisplayName("Dual Gross Ton")]
        public double? DualGrossTon { get; set; }

        ///<summary>
        /// Get or Set the NetTon Property of Vessel
        /// NetTon is Nullable 
        ///</summary>


        [DisplayName("Net Ton")]
        public double? NetTon { get; set; }

        ///<summary>
        /// Get or Set the DualNetTon Property of Vessel
        /// DualNetTon is Nullable 
        ///</summary>


        [DisplayName("Dual Net Ton")]
        public double? DualNetTon { get; set; }

        ///<summary>
        /// Get or Set the DeadWeightTon Property of Vessel
        /// DeadWeightTon is Nullable 
        ///</summary>


        [DisplayName("Dead Weight Ton")]
        public double? DeadWeightTon { get; set; }

        ///<summary>
        /// Get or Set the NumberofDeck Property of Vessel
        /// NumberofDeck is Nullable 
        ///</summary>


        [DisplayName("Numberof Deck")]
        public int? NumberofDeck { get; set; }

        ///<summary>
        /// Get or Set the Breadth Property of Vessel
        /// Breadth is Nullable 
        ///</summary>


        [DisplayName("Breadth")]
        public double? Breadth { get; set; }

        ///<summary>
        /// Get or Set the Depth Property of Vessel
        /// Depth is Nullable 
        ///</summary>


        [DisplayName("Depth")]
        public double? Depth { get; set; }

        ///<summary>
        /// Get or Set the Height Property of Vessel
        /// Height is Nullable 
        ///</summary>


        [DisplayName("Height")]
        public double? Height { get; set; }

        ///<summary>
        /// Get or Set the Length Property of Vessel
        /// Length is Nullable 
        ///</summary>


        [DisplayName("Length")]
        public double? Length { get; set; }

        ///<summary>
        /// Get or Set the Masts Property of Vessel
        /// Masts is Nullable 
        ///</summary>


        [DisplayName("Masts")]
        public int? Masts { get; set; }

        ///<summary>
        /// Get or Set the Power Property of Vessel
        /// Power is Nullable 
        ///</summary>


        [DisplayName("Power")]
        public decimal? Power { get; set; }

        ///<summary>
        /// Get or Set the LengthITC Property of Vessel
        /// LengthITC is Nullable 
        ///</summary>


        [DisplayName("Length ITC")]
        public double? LengthITC { get; set; }

        ///<summary>
        /// Get or Set the BuiltYear Property of Vessel
        /// BuiltYear is Nullable 
        ///</summary>


        [DisplayName("Built Year")]
        public int? BuiltYear { get; set; }

        ///<summary>
        /// Get or Set the Builder Property of Vessel
        /// Builder is Nullable 
        ///</summary>

        [StringLength(75)]
        [DisplayName("Builder")]
        public string Builder { get; set; }

        ///<summary>
        /// Get or Set the PlaceBuilt Property of Vessel
        /// PlaceBuilt is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Place Built")]
        public string PlaceBuilt { get; set; }

        ///<summary>
        /// Get or Set the EngineManufacturer Property of Vessel
        /// EngineManufacturer is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Engine Manufacturer")]
        public string EngineManufacturer { get; set; }

        ///<summary>
        /// Get or Set the EngineType Property of Vessel
        /// EngineType is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Engine Type")]
        public string EngineType { get; set; }

        ///<summary>
        /// Get or Set the MeasuringUnit Property of Vessel
        /// MeasuringUnit is Nullable 
        ///</summary>


        [DisplayName("Measuring Unit")]
        public int? MeasuringUnit { get; set; }

        ///<summary>
        /// Get or Set the ClassSociety Property of Vessel
        /// ClassSociety is Nullable 
        ///</summary>


        [DisplayName("Class Society")]
        public int? ClassSociety { get; set; }

        ///<summary>
        /// Get or Set the BareBoatType Property of Vessel
        /// BareBoatType is Nullable 
        ///</summary>


        [DisplayName("Bare Boat Type")]
        public int? BareBoatType { get; set; }

        ///<summary>
        /// Get or Set the FromRegistry Property of Vessel
        /// FromRegistry is Nullable 
        ///</summary>


        [DisplayName("From Registry")]
        public int? FromRegistry { get; set; }

        ///<summary>
        /// Get or Set the PortOfRegistry Property of Vessel
        /// PortOfRegistry is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Port Of Registry")]
        public string PortOfRegistry { get; set; }

        ///<summary>
        /// Get or Set the DateOfConstruction Property of Vessel
        /// DateOfConstruction is Nullable 
        ///</summary>


        [DisplayName("Date Of Construction")]
        public DateTime? DateOfConstruction { get; set; }

        ///<summary>
        /// Get or Set the ConstructionDateTypeId Property of Vessel
        /// ConstructionDateTypeId is Nullable 
        ///</summary>


        [DisplayName("Construction Date Type Id")]
        public int? ConstructionDateTypeId { get; set; }

        ///<summary>
        /// Get or Set the HullNumber Property of Vessel
        /// HullNumber is Nullable 
        ///</summary>

        [StringLength(15)]
        [DisplayName("Hull Number")]
        public string HullNumber { get; set; }

        ///<summary>
        /// Get or Set the HullMaterial Property of Vessel
        /// HullMaterial is Nullable 
        ///</summary>


        [DisplayName("Hull Material")]
        public int? HullMaterial { get; set; }

        ///<summary>
        /// Get or Set the BareBoatRegistry Property of Vessel
        /// BareBoatRegistry is Nullable 
        ///</summary>


        [DisplayName("Bare Boat Registry")]
        public int? BareBoatRegistry { get; set; }

        ///<summary>
        /// Get or Set the CharterFileDate Property of Vessel
        /// CharterFileDate is Nullable 
        ///</summary>


        [DisplayName("Charter File Date")]
        public DateTime? CharterFileDate { get; set; }

        ///<summary>
        /// Get or Set the CharterExpiryDate Property of Vessel
        /// CharterExpiryDate is Nullable 
        ///</summary>


        [DisplayName("Charter Expiry Date")]
        public DateTime? CharterExpiryDate { get; set; }

        ///<summary>
        /// Get or Set the StrickenReason Property of Vessel
        /// StrickenReason is Nullable 
        ///</summary>


        [DisplayName("Stricken Reason")]
        public int? StrickenReason { get; set; }

        ///<summary>
        /// Get or Set the TransferToRegistry Property of Vessel
        /// TransferToRegistry is Nullable 
        ///</summary>


        [DisplayName("Transfer To Registry")]
        public int? TransferToRegistry { get; set; }

        ///<summary>
        /// Get or Set the TonnageTaxCode Property of Vessel
        /// TonnageTaxCode is Nullable 
        ///</summary>


        [DisplayName("Tonnage Tax Code")]
        public int? TonnageTaxCode { get; set; }

        ///<summary>
        /// Get or Set the VesselLookup Property of Vessel
        /// VesselLookup is Not Nullable
        ///</summary>
        [Required]
        [StringLength(186)]
        [DisplayName("Vessel Lookup")]
        public string VesselLookup { get; set; }

        ///<summary>
        /// Get or Set the MMSI Property of Vessel
        /// MMSI is Nullable 
        ///</summary>


        [DisplayName("MMSI")]
        public int? MMSI { get; set; }
        /// <summary>
        /// Get or set IsDeletedDueToSanctions 
        /// </summary>

        [DisplayName("Deletion due to sanctions")]
        public bool IsDeletedDueToSanctions { get; set; } = false;

        ///<summary>
        /// Get or Set the ConversionYear Property of Vessel
        /// ConversionYear is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Conversion Year")]
        public string ConversionYear { get; set; }


        ///<summary>
        /// Get or Set the DateOfBuildingContract Property of WorkOrderVessel
        /// DateOfBuildingContract is Nullable 
        ///</summary>

        [DisplayName("Date Of Building Contract")]
        public DateTime? DateOfBuildingContract { get; set; }


        [DisplayName("DateOfBuildingContract NotApplicable")]
        public bool DateOfBuildingContractNotApplicable { get; set; }

        ///<summary>
        /// Get or Set the DateOnWhichKeelWasLaid Property of WorkOrderVessel
        /// DateOnWhichKeelWasLaid is Nullable 
        ///</summary>

        [DisplayName("Date On Which Keel Was Laid")]
        public DateTime? DateOnWhichKeelWasLaid { get; set; }

        ///<summary>
        /// Get or Set the DateOfDelivery Property of WorkOrderVessel
        /// DateOfDelivery is Nullable 
        ///</summary>

        [DisplayName("Date Of Delivery")]
        public DateTime? DateOfDelivery { get; set; }

        [DisplayName("Is Vessel Sanctioned")]
        public bool IsVesselSanctioned { get; set; }

        #endregion

        #region Override Methods

        ///<summary>
        ///Sets the Model from reader
        ///Assigns values to Model from Reader
        ///</summary>
        #endregion

    }
}
