namespace WayPoint.Model
{
    public partial class Entity
    {
        [DbIgnore]
        public int IMONumber { get; set; }
        [DbIgnore]
        public int? ClientId { get; set; }
        [DbIgnore]
        public int? ClientNumber { get; set; }
        [DbIgnore]
        public int? OfficialNumber { get; set; }
        [DbIgnore]
        public string EntityTypeName { get; set; } = string.Empty;
        [DbIgnore]
        public int? VesselId { get; set; }
        [DbIgnore]
        public int? CorporateId { get; set; }
    }
}
