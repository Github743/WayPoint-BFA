using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class Client
    {
        public string StatusName { get; set; } = string.Empty;
        public string BusinessTypeName { get; set; } = string.Empty;
        public bool ClientSelected { get; set; }
        [DisplayName("TOTAL VESSELS")]
        public int TotalVessels { get; set; }
        public List<string> Notes { get; set; } = [];
        public string ShortName { get; set; } = string.Empty;
        public string ClientRole { get; set; } = string.Empty;
        public bool IsLiscr { get; set; }
        public string CountryAlpha3Code { get; set; } = string.Empty;
        public string AddressTypeName { get; set; } = string.Empty;
        public string LegacyValue { get; set; } = string.Empty;
    }
}
