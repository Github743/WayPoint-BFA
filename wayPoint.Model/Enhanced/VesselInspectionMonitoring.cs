using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselInspectionMonitoring
    {
        public bool IsNonRegulatory { get; set; }
        public DateTime StartDate { get; set; }
        public string ProgramTypeName { get; set; }
    }
}
