using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselContact
    {
        public int? PersonId { get; set; }
        public string PersonName { get; set; }
        public int? PersonRoleId { get; set; }
        public string PersonRoleName { get; set; }
        public int? IMONumber { get; set; }
        public int? OfficialNumber { get; set; }
        public string VesselName { get; set; }
        public double? NetTon { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string StatusName { get; set; }
        public string VesselTypeName { get; set; }
        public string FlagStateName { get; set; }
        public string ContactType { get; set; }

        public int? ContactPersonRoleId { get; set; }

        public int? PersonEntityId { get; set; }
    }
}
