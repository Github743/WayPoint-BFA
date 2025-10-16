using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WayPoint.Model
{
    public partial class Vessel
    {
        public WorkOrderVessel GetWorkOrderVessel()
        {
            WorkOrderVessel result = new WorkOrderVessel()
            {
                BareBoatType = BareBoatType,
                Breadth = Breadth,
                Builder = Builder,
                BuiltYear = BuiltYear,
                CallSign = CallSign,
                PortOfRegistry = PortOfRegistry,
                ClassSociety = ClassSociety,
                DeadWeightTon = DeadWeightTon,
                Depth = Depth,
                DualGrossTon = DualGrossTon,
                DualNetTon = DualNetTon,
                EngineManufacturer = EngineManufacturer,
                EngineType = EngineType,
                FlagState = FlagState,
                FromRegistry = FromRegistry,
                GrossTon = GrossTon,
                Height = Height,
                IMONumber = IMONumber,
                Length = Length,
                LengthITC = LengthITC,
                Masts = Masts,
                MeasuringUnit = MeasuringUnit,
                Name = Name,
                NetTon = NetTon,
                NumberofDeck = NumberofDeck,
                OfficialNumber = OfficialNumber,
                OriginalRegistrationDate = OriginalRegistrationDate,
                PlaceBuilt = PlaceBuilt,
                Power = Power,
                Propulsion = Propulsion,
                RegistrationDate = RegistrationDate,
                ReRegistrationDate = ReRegistrationDate,
                Status = Status,
                StrickenDate = StrickenDate,
                VesselId = VesselId,
                VesselTypeId = VesselTypeId,
                DateOfConstruction = DateOfConstruction,
                BareBoatRegistry = BareBoatRegistry,
                CharterExpiryDate = CharterExpiryDate,
                CharterFileDate = CharterFileDate,
                TonnageTaxCode = TonnageTaxCode,
                TransferToRegistry = TransferToRegistry,
                StrickenReason = StrickenReason,
                HullNumber = HullNumber,
                HullMaterial = HullMaterial,
                BillingPrefixLine1 = BillingAddressPrefix1,
                BillingPrefixLine2 = BillingAddressPrefix2,
                ConversionYear = ConversionYear,
                DateOfBuildingContract = DateOfBuildingContract,
                DateOfBuildingContractNotApplicable = DateOfBuildingContractNotApplicable,
                DateOnWhichKeelWasLaid = DateOnWhichKeelWasLaid,
                DateOfDelivery = DateOfDelivery
            };

            if (VesselId != -1)
                result.VesselId = VesselId;
            else
                result.VesselId = null;

            return result;
        }

        public string StatusName { get; set; }
        public string FlagStateName { get; set; }
        public string VesselTypeName { get; set; }

        [DisplayName("Vessel Type")]
        public string VesselTypeDisplayName { get; set; }
        public string ParentVesselTypeName { get; set; }
        public string ParentVesselTypeDisplayName { get; set; }
        public string BareBoatTypeName { get; set; }
        [DisplayName("Bareboat Flag")]
        public string BareBoatRegistryName { get; set; }
        //[DisplayName("From")]
        public string FromRegistryName { get; set; }
        //public string CategoryName { get; set; }
        [DisplayName("Op Codes")]
        public string OperName { get; set; }

        [DisplayName("Class")]
        public string ClassSocietyName { get; set; }

        [DisplayName("Hull Material")]
        public string HullMaterialName { get; set; }

        [DisplayName("Propulsion")]
        public string PropulsionName { get; set; }

        [DisplayName("Unit of Measure")]
        public string MeasureUnitName { get; set; }

        //public string MMSI { get; set; }
        public string StatusCode { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string ClientRoleNames { get; set; }

        public int? OpCode { get; set; }
        public int? TypeId { get; set; }
        public int? SubTypeId { get; set; }
        public int? FlagStateId { get; set; }

        public string LegacyVesselTypeId { get; set; }

        public bool IsLiberian
        {
            get
            {
                return FlagStateName == ApplicationConstants.FLAGSTATE_LIBERIA;
            }
        }

        /// <summary>
        /// Get or Set the list of vessel owerns
        /// </summary>
        public List<VesselOwner> VesselOwners { get; set; }

        /// <summary>
        /// Get or Sets the vessel parent type id
        /// </summary>
        public int? ParentTypeId { get; set; }

        /// <summary>
        /// Get or Set the Parent Type Name
        /// </summary>
        public string ParentTypeName { get; set; }

        /// <summary>
        /// Get or Set the Mesuring Unit Name
        /// </summary>
        public string MeasuringUnitName { get; set; }

        /// <summary>
        /// Get or Set Lis Associated party types 
        /// </summary>
        public List<string> LisAssociatedPartyTypes
        { get; set; }

        [DisplayName("Stricken Reason")]
        public string StrickenReasonName { get; set; }

        [DisplayName("Billing Address Prefix1")]
        public string BillingAddressPrefix1 { get; set; }

        [DisplayName("Billing Address Prefix2")]
        public string BillingAddressPrefix2 { get; set; }

        public bool? IsBFAEnrolled { get; set; }

        [DisplayName("Transfer To Registry")]
        public string TransferToRegistryName { get; set; }

        [MaxLength(150)]
        public string IMOSearch { get; set; }

        [MaxLength(4000)]
        public string VesselIdList { get; set; }
        public string LegacyFromRegistry { get; set; }

        public string LegacyPropulsion { get; set; }
        public string LegacyHullMaterial { get; set; }
        public string LegacyMeasuringUnit { get; set; }
        public string LegacyClassSociety { get; set; }


        public string LegacyStrickenReasonName { get; set; }
        public int headerMenuId { get; set; }

        public bool? IsLiscr { get; set; }

        public string LegacyBareBoatType { get; set; }

        public string LegacyBareBoatRegistry { get; set; }

        public bool RequireQuarterlyInspection { get; set; }

        public bool RequireBiAnnualInspection { get; set; }

        //used for tonnage annual invoice workorder
        //public bool? RequireBiAnnualInspectionForTonnageBilling {  get; set; }
        ////used for tonnage annual invoice workorder
        //public int? BiAnnualProgramType {  get; set; }
    } // end class
}
