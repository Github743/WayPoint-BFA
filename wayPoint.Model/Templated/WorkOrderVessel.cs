using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    [Table("WorkOrderVessel", Schema = "WO")]
    public partial class WorkOrderVessel : BaseModel
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
        /// Get or Set the Id property of WorkOrderVessel
        ///</summary>

        [NotMapped]
        public int Id { get { return WorkOrderVesselId; } set { WorkOrderVesselId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderVesselId Property of WorkOrderVessel
        /// WorkOrderVesselId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Vessel Id")]
        public int WorkOrderVesselId { get; set; }

        ///<summary>
        /// Get or Set the VesselId Property of WorkOrderVessel
        /// VesselId is Nullable 
        ///</summary>


        [DisplayName("Vessel Id")]
        public int? VesselId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderEntityId Property of WorkOrderVessel
        /// WorkOrderEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of WorkOrderVessel
        /// Name is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the IMONumber Property of WorkOrderVessel
        /// IMONumber is Nullable 
        ///</summary>


        [DisplayName("IMO Number")]
        public int? IMONumber { get; set; }

        ///<summary>
        /// Get or Set the OfficialNumber Property of WorkOrderVessel
        /// OfficialNumber is Nullable 
        ///</summary>


        [DisplayName("Official Number")]
        public int? OfficialNumber { get; set; }

        ///<summary>
        /// Get or Set the CallSign Property of WorkOrderVessel
        /// CallSign is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Call Sign")]
        public string CallSign { get; set; }

        ///<summary>
        /// Get or Set the Status Property of WorkOrderVessel
        /// Status is Nullable 
        ///</summary>


        [DisplayName("Status")]
        public int? Status { get; set; }

        ///<summary>
        /// Get or Set the FlagState Property of WorkOrderVessel
        /// FlagState is Not Nullable
        ///</summary>


        [DisplayName("Flag State")]
        public int FlagState { get; set; }

        ///<summary>
        /// Get or Set the VesselTypeId Property of WorkOrderVessel
        /// VesselTypeId is Nullable 
        ///</summary>


        [DisplayName("Vessel Type Id")]
        public int? VesselTypeId { get; set; }

        ///<summary>
        /// Get or Set the Propulsion Property of WorkOrderVessel
        /// Propulsion is Nullable 
        ///</summary>


        [DisplayName("Propulsion")]
        public int? Propulsion { get; set; }

        ///<summary>
        /// Get or Set the OriginalRegistrationDate Property of WorkOrderVessel
        /// OriginalRegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Original Registration Date")]
        public DateTime? OriginalRegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the RegistrationDate Property of WorkOrderVessel
        /// RegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Registration Date")]
        public DateTime? RegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the ReRegistrationDate Property of WorkOrderVessel
        /// ReRegistrationDate is Nullable 
        ///</summary>


        [DisplayName("Re Registration Date")]
        public DateTime? ReRegistrationDate { get; set; }

        ///<summary>
        /// Get or Set the StrickenDate Property of WorkOrderVessel
        /// StrickenDate is Nullable 
        ///</summary>


        [DisplayName("Stricken Date")]
        public DateTime? StrickenDate { get; set; }

        ///<summary>
        /// Get or Set the GrossTon Property of WorkOrderVessel
        /// GrossTon is Nullable 
        ///</summary>


        [DisplayName("Gross Ton")]
        public double? GrossTon { get; set; }

        ///<summary>
        /// Get or Set the DualGrossTon Property of WorkOrderVessel
        /// DualGrossTon is Nullable 
        ///</summary>


        [DisplayName("Dual Gross Ton")]
        public double? DualGrossTon { get; set; }

        ///<summary>
        /// Get or Set the NetTon Property of WorkOrderVessel
        /// NetTon is Nullable 
        ///</summary>


        [DisplayName("Net Ton")]
        public double? NetTon { get; set; }

        ///<summary>
        /// Get or Set the DualNetTon Property of WorkOrderVessel
        /// DualNetTon is Nullable 
        ///</summary>


        [DisplayName("Dual Net Ton")]
        public double? DualNetTon { get; set; }

        ///<summary>
        /// Get or Set the DeadWeightTon Property of WorkOrderVessel
        /// DeadWeightTon is Nullable 
        ///</summary>


        [DisplayName("Dead Weight Ton")]
        public double? DeadWeightTon { get; set; }

        ///<summary>
        /// Get or Set the NumberofDeck Property of WorkOrderVessel
        /// NumberofDeck is Nullable 
        ///</summary>


        [DisplayName("Numberof Deck")]
        public int? NumberofDeck { get; set; }

        ///<summary>
        /// Get or Set the Breadth Property of WorkOrderVessel
        /// Breadth is Nullable 
        ///</summary>


        [DisplayName("Breadth")]
        public double? Breadth { get; set; }

        ///<summary>
        /// Get or Set the Depth Property of WorkOrderVessel
        /// Depth is Nullable 
        ///</summary>


        [DisplayName("Depth")]
        public double? Depth { get; set; }

        ///<summary>
        /// Get or Set the Height Property of WorkOrderVessel
        /// Height is Nullable 
        ///</summary>


        [DisplayName("Height")]
        public double? Height { get; set; }

        ///<summary>
        /// Get or Set the Length Property of WorkOrderVessel
        /// Length is Nullable 
        ///</summary>


        [DisplayName("Length")]
        public double? Length { get; set; }

        ///<summary>
        /// Get or Set the Masts Property of WorkOrderVessel
        /// Masts is Nullable 
        ///</summary>


        [DisplayName("Masts")]
        public int? Masts { get; set; }

        ///<summary>
        /// Get or Set the Power Property of WorkOrderVessel
        /// Power is Nullable 
        ///</summary>


        [DisplayName("Power")]
        public decimal? Power { get; set; }

        ///<summary>
        /// Get or Set the LengthITC Property of WorkOrderVessel
        /// LengthITC is Nullable 
        ///</summary>


        [DisplayName("Length ITC")]
        public double? LengthITC { get; set; }

        ///<summary>
        /// Get or Set the BuiltYear Property of WorkOrderVessel
        /// BuiltYear is Nullable 
        ///</summary>


        [DisplayName("Built Year")]
        public int? BuiltYear { get; set; }

        ///<summary>
        /// Get or Set the Builder Property of WorkOrderVessel
        /// Builder is Nullable 
        ///</summary>

        [StringLength(75)]
        [DisplayName("Builder")]
        public string Builder { get; set; }

        ///<summary>
        /// Get or Set the PlaceBuilt Property of WorkOrderVessel
        /// PlaceBuilt is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Place Built")]
        public string PlaceBuilt { get; set; }

        ///<summary>
        /// Get or Set the EngineManufacturer Property of WorkOrderVessel
        /// EngineManufacturer is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Engine Manufacturer")]
        public string EngineManufacturer { get; set; }

        ///<summary>
        /// Get or Set the EngineType Property of WorkOrderVessel
        /// EngineType is Nullable 
        ///</summary>

        [StringLength(60)]
        [DisplayName("Engine Type")]
        public string EngineType { get; set; }

        ///<summary>
        /// Get or Set the MeasuringUnit Property of WorkOrderVessel
        /// MeasuringUnit is Nullable 
        ///</summary>


        [DisplayName("Measuring Unit")]
        public int? MeasuringUnit { get; set; }

        ///<summary>
        /// Get or Set the ClassSociety Property of WorkOrderVessel
        /// ClassSociety is Nullable 
        ///</summary>


        [DisplayName("Class Society")]
        public int? ClassSociety { get; set; }

        ///<summary>
        /// Get or Set the BareBoatType Property of WorkOrderVessel
        /// BareBoatType is Nullable 
        ///</summary>


        [DisplayName("Bare Boat Type")]
        public int? BareBoatType { get; set; }

        ///<summary>
        /// Get or Set the FromRegistry Property of WorkOrderVessel
        /// FromRegistry is Nullable 
        ///</summary>


        [DisplayName("From Registry")]
        public int? FromRegistry { get; set; }

        ///<summary>
        /// Get or Set the PortOfRegistry Property of WorkOrderVessel
        /// PortOfRegistry is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Port Of Registry")]
        public string PortOfRegistry { get; set; }

        ///<summary>
        /// Get or Set the DateOfConstruction Property of WorkOrderVessel
        /// DateOfConstruction is Nullable 
        ///</summary>


        [DisplayName("Date Of Construction")]
        public DateTime? DateOfConstruction { get; set; }

        ///<summary>
        /// Get or Set the ConstructionDateTypeId Property of WorkOrderVessel
        /// ConstructionDateTypeId is Nullable 
        ///</summary>


        [DisplayName("Construction Date Type Id")]
        public int? ConstructionDateTypeId { get; set; }

        ///<summary>
        /// Get or Set the HullNumber Property of WorkOrderVessel
        /// HullNumber is Nullable 
        ///</summary>

        [StringLength(15)]
        [DisplayName("Hull Number")]
        public string HullNumber { get; set; }

        ///<summary>
        /// Get or Set the HullMaterial Property of WorkOrderVessel
        /// HullMaterial is Nullable 
        ///</summary>


        [DisplayName("Hull Material")]
        public int? HullMaterial { get; set; }

        ///<summary>
        /// Get or Set the BareBoatRegistry Property of WorkOrderVessel
        /// BareBoatRegistry is Nullable 
        ///</summary>


        [DisplayName("Bare Boat Registry")]
        public int? BareBoatRegistry { get; set; }

        ///<summary>
        /// Get or Set the CharterFileDate Property of WorkOrderVessel
        /// CharterFileDate is Nullable 
        ///</summary>


        [DisplayName("Charter File Date")]
        public DateTime? CharterFileDate { get; set; }

        ///<summary>
        /// Get or Set the CharterExpiryDate Property of WorkOrderVessel
        /// CharterExpiryDate is Nullable 
        ///</summary>


        [DisplayName("Charter Expiry Date")]
        public DateTime? CharterExpiryDate { get; set; }

        ///<summary>
        /// Get or Set the StrickenReason Property of WorkOrderVessel
        /// StrickenReason is Nullable 
        ///</summary>


        [DisplayName("Stricken Reason")]
        public int? StrickenReason { get; set; }

        ///<summary>
        /// Get or Set the TransferToRegistry Property of WorkOrderVessel
        /// TransferToRegistry is Nullable 
        ///</summary>


        [DisplayName("Transfer To Registry")]
        public int? TransferToRegistry { get; set; }

        ///<summary>
        /// Get or Set the TonnageTaxCode Property of WorkOrderVessel
        /// TonnageTaxCode is Nullable 
        ///</summary>


        [DisplayName("Tonnage Tax Code")]
        public int? TonnageTaxCode { get; set; }

        ///<summary>
        /// Get or Set the BillingPrefixLine1 Property of WorkOrderInvoice
        /// BillingPrefixLine1 is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Billing Prefix Line 1")]
        public string BillingPrefixLine1 { get; set; }

        ///<summary>
        /// Get or Set the BillingPrefixLine2 Property of WorkOrderInvoice
        /// BillingPrefixLine2 is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Billing Prefix Line 2")]
        public string BillingPrefixLine2 { get; set; }


        [DisplayName("Deletion due to sanctions")]
        public bool IsDeletedDueToSanctions { get; set; } = false;
        [NotMapped]
        [DisplayName("Original Vessel Deletion due to sanctions")]
        public bool IsOriginalVesselDeletedDueToSanctions { get; set; } = false;
        ///<summary>
        /// Get or Set the ConversionYear Property of WorkOrderVessel
        /// ConversionYear is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Conversion Year")]
        public string ConversionYear { get; set; }

        ///<summary>
        /// Get or Set the DateOfBuildingContract Property of WorkOrderVessel
        /// DateOfBuildingContract is Nullable 
        ///</summary>
        [NotMapped]
        [DisplayName("Date Of Building Contract")]
        public DateTime? DateOfBuildingContract { get; set; }

        [NotMapped]
        [DisplayName("DateOfBuildingContract NotApplicable")]
        public bool DateOfBuildingContractNotApplicable { get; set; }

        ///<summary>
        /// Get or Set the DateOnWhichKeelWasLaid Property of WorkOrderVessel
        /// DateOnWhichKeelWasLaid is Nullable 
        ///</summary>
        [NotMapped]
        [DisplayName("Date On Which Keel Was Laid")]
        public DateTime? DateOnWhichKeelWasLaid { get; set; }

        ///<summary>
        /// Get or Set the DateOfDelivery Property of WorkOrderVessel
        /// DateOfDelivery is Nullable 
        ///</summary>
        [NotMapped]
        [DisplayName("Date Of Delivery")]
        public DateTime? DateOfDelivery { get; set; }
        [NotMapped]
        [DisplayName("Survey Completion Date")]
        public DateTime? SurveyCompletionDate { get; set; }
        #endregion
    }
}
