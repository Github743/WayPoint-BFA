using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    public partial class WorkOrderEntity
    {
        [DbIgnore]
        [NotMapped]
        public string VesselName { get; set; } = string.Empty;
        
        [DbIgnore]
        [NotMapped]
        public float? VesselGrossTon { get; set; }

        [DbIgnore]
        [NotMapped]
        public string VesselTypeName { get; set; } = string.Empty;

        [DbIgnore]
        [NotMapped]
        public bool? VesselTypeRequireCLC { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? VesselFlagState { get; set; }

        [DbIgnore]
        [NotMapped]
        public bool IsLiberian { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? ClientId { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? ClientNumber { get; set; }

        [DbIgnore]
        [NotMapped]
        public string ClientName { get; set; } = string.Empty;

        [DbIgnore]
        [NotMapped]
        public int? ClientBusinessType { get; set; }

        [DbIgnore]
        [NotMapped]
        public string ClientBusinessTypeName { get; set; } = string.Empty;

        [DbIgnore]
        [NotMapped]
        public int? Status { get; set; }

        [DbIgnore]
        [NotMapped]
        public string ClientStatusName { get; set; } = string.Empty;

        [DbIgnore]
        [NotMapped]
        public string EntityName { get; set; } = string.Empty;

        [DbIgnore]
        [NotMapped]
        public int? VesselId { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? IMONumber { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? OrigVesselId { get; set; }

        [DbIgnore]
        [NotMapped]
        public string EntityTypeName { get; set; } = string.Empty;
    }
}
