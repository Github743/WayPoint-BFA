using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public class VesselSearch
    {
        public int IMO { get; set; }

        public int? OfficialNumber { get; set; }
        public string Name { get; set; }
        public int VesselId { get; set; }

        public string IdentificationColumn { get; set; }
        public bool? NonLibFlag { get; set; }

        public bool IsBFAEnrolled { get; set; }
        public int? EntityId { get; set; }
        public bool IsVesselSanctioned { get; set; }
    }
}
