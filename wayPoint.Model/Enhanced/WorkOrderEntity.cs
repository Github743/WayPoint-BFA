namespace WayPoint.Model
{
    public partial class WorkOrderEntity
    {
        [DbIgnore]
        public string VesselName { get; set; } = string.Empty;

        [DbIgnore]
        public float? VesselGrossTon { get; set; }

        [DbIgnore]
        public string VesselTypeName { get; set; } = string.Empty;

        [DbIgnore]
        public bool? VesselTypeRequireCLC { get; set; }

        [DbIgnore]
        public int? VesselFlagState { get; set; }

        [DbIgnore]
        public bool IsLiberian { get; set; }

        [DbIgnore]
        public int? ClientId { get; set; }

        [DbIgnore]
        public int? ClientNumber { get; set; }

        [DbIgnore]
        public string ClientName { get; set; } = string.Empty;

        [DbIgnore]
        public int? ClientBusinessType { get; set; }

        [DbIgnore]
        public string ClientBusinessTypeName { get; set; } = string.Empty;

        [DbIgnore]
        public int? Status { get; set; }

        [DbIgnore]
        public string ClientStatusName { get; set; } = string.Empty;

        [DbIgnore]
        public string EntityName { get; set; } = string.Empty;

        [DbIgnore]
        public int? VesselId { get; set; }

        [DbIgnore]
        public int? IMONumber { get; set; }

        [DbIgnore]
        public int? OrigVesselId { get; set; }

        [DbIgnore]
        public string EntityTypeName { get; set; } = string.Empty;
    }
}
