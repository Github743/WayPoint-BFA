using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class ClientAgreementEntities
    {

        public string SystemDiscountProgramTypeName { get; set; }
        public string SystemDiscountProgramName { get; set; }
        public string SystemDiscountScheduleName { get; set; }
        public int? VesselId { get; set; }
        public int? OfficialNumber { get; set; }
        public string EntityTypeName { get; set; }
        public int? ClientId { get; set; }
        public int? ClientNumber { get; set; }
        public string TonnageTaxPriceModelName { get; set; }
    }
}
