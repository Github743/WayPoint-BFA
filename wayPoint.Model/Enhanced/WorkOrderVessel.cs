using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayPoint.Model.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    public partial class WorkOrderVessel
    {
        [NotMapped]
        public string StatusName { get; set; }
        [NotMapped]
        public string FlagStateName { get; set; }
        [NotMapped]
        public string ParentVesselTypeName { get; set; }
        [NotMapped]
        public int? ParentVesselTypeId { get; set; }
        [NotMapped]
        public string ParentVesselTypeDisplayName { get; set; }
        [NotMapped]
        [DisplayName("Vessel Type")]
        public string VesselTypeDisplayName { get; set; }
        [NotMapped]
        public string VesselTypeName { get; set; }
        [NotMapped]
        public string BareBoatTypeName { get; set; }
        [NotMapped]
        public bool NonLiberianActivity { get; set; }
        [NotMapped]
        public int? DefaultBillToClientRole { get; set; }
        [NotMapped]
        public string SystemWorkOrderName { get; set; }
        [NotMapped]
        public int? SystemWorkOrderId { get; set; }
        [NotMapped]
        public string WorkOrderStatus { get; set; }
        [NotMapped]
        public int? WorkOrderId { get; set; }
        [NotMapped]
        public string WorkOrderStatusDisplayName { get; set; }
        [NotMapped]
        public string ConstructionDateTypeName { get; set; }
        [NotMapped]
        public string ClassSocietyName { get; set; }
        [NotMapped]
        public List<int> selectedClassSocieties { get; set; } = new();
        [NotMapped]
        public string FromRegistryName { get; set; }
        [NotMapped]
        public string PropulsionName { get; set; }
        [NotMapped]

        public string HullMaterialName { get; set; }
        [NotMapped]
        public string MeasuringUnitName { get; set; }
        [NotMapped]
        public string OriginalVesselStatusName { get; set; }
        public Vessel UpdateVesselDetails(Vessel vessel)
        {
            vessel.Name = Name;
            vessel.IMONumber = IMONumber;
            vessel.OfficialNumber = OfficialNumber;
            vessel.CallSign = CallSign;
            vessel.Status = Status;
            vessel.FlagState = FlagState;
            vessel.VesselTypeId = VesselTypeId;
            vessel.Propulsion = VesselTypeId;
            vessel.OriginalRegistrationDate = OriginalRegistrationDate;
            vessel.RegistrationDate = RegistrationDate;
            vessel.ReRegistrationDate = ReRegistrationDate;
            vessel.StrickenDate = StrickenDate;
            vessel.GrossTon = GrossTon;
            vessel.DualGrossTon = DualGrossTon;
            vessel.NetTon = NetTon;
            vessel.DualNetTon = DualNetTon;
            vessel.DeadWeightTon = DeadWeightTon;
            vessel.NumberofDeck = NumberofDeck;
            vessel.Breadth = Breadth;
            vessel.Depth = Depth;
            vessel.Height = Height;
            vessel.Length = Length;
            vessel.Masts = Masts;
            vessel.Power = Power;
            vessel.LengthITC = LengthITC;
            vessel.BuiltYear = BuiltYear;
            vessel.Builder = Builder;
            vessel.PlaceBuilt = PlaceBuilt;
            vessel.EngineManufacturer = EngineManufacturer;
            vessel.EngineType = EngineType;
            vessel.MeasuringUnit = MeasuringUnit;
            vessel.ClassSociety = ClassSociety;
            vessel.BareBoatType = BareBoatType;
            vessel.FromRegistry = FromRegistry;
            vessel.PortOfRegistry = PortOfRegistry;
            vessel.DateOfConstruction = DateOfConstruction;

            return vessel;
        }

        public void UpdateWorkOrderVesselDetails(Vessel vessel)
        {
            Name = vessel.Name;
            IMONumber = vessel.IMONumber;
            OfficialNumber = vessel.OfficialNumber;
            CallSign = vessel.CallSign;
            Status = vessel.Status;
            FlagState = vessel.FlagState;
            VesselTypeId = vessel.VesselTypeId;
            Propulsion = vessel.VesselTypeId;
            OriginalRegistrationDate = vessel.OriginalRegistrationDate;
            RegistrationDate = vessel.RegistrationDate;
            ReRegistrationDate = vessel.ReRegistrationDate;
            StrickenDate = vessel.StrickenDate;
            GrossTon = vessel.GrossTon;
            DualGrossTon = vessel.DualGrossTon;
            NetTon = vessel.NetTon;
            DualNetTon = vessel.DualNetTon;
            DeadWeightTon = vessel.DeadWeightTon;
            NumberofDeck = vessel.NumberofDeck;
            Breadth = vessel.Breadth;
            Depth = vessel.Depth;
            Height = vessel.Height;
            Length = vessel.Length;
            Masts = vessel.Masts;
            Power = vessel.Power;
            LengthITC = vessel.LengthITC;
            BuiltYear = vessel.BuiltYear;
            Builder = vessel.Builder;
            PlaceBuilt = vessel.PlaceBuilt;
            EngineManufacturer = vessel.EngineManufacturer;
            EngineType = vessel.EngineType;
            MeasuringUnit = vessel.MeasuringUnit;
            ClassSociety = vessel.ClassSociety;
            BareBoatType = vessel.BareBoatType;
            FromRegistry = vessel.FromRegistry;
            PortOfRegistry = vessel.PortOfRegistry;
            DateOfConstruction = vessel.DateOfConstruction;
        }

        public Vessel GetNewVessel()
        {
            Vessel vessel = new Vessel();
            return UpdateVesselDetails(vessel);
        }
        ///<summary>
        /// Get or Set the OpCodeNames Property of WorkOrderVessel
        /// OpCodeName is Nullable 
        ///</summary>
        //[DbIgnore]
        [NotMapped]
        [DisplayName("Op Code Names")]
        public string OperName { get; set; }
        [NotMapped]
        public string LegacyVesselTypeId { get; set; }
        [NotMapped]
        public bool isLiscr { get; set; }
        [NotMapped]
        public VesselReservedNameViewModel vesselReservedNameViewModel { get; set; }
        [NotMapped]
        public int EntityId { get; set; }

    }
}
