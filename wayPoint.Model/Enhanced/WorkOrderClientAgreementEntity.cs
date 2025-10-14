using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderClientAgreementEntity
    {

        #region Properties
        [NotMapped]
        public int? VesselId { get; set; }
        [NotMapped]
        public int? OfficialNumber { get; set; }
        [NotMapped]
        public int? IMONumber { get; set; }
        [NotMapped]
        public string VesselName { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public int ClientId { get; set; }
        [NotMapped]
        public int? VesselStatus { get; set; }
        [NotMapped]
        public string VesselStatusName { get; set; }
        [NotMapped]
        public string BillToClientName { get; set; }
        [NotMapped]
        public string BillingCycleName { get; set; }
        [NotMapped]
        public List<Lookup> BillToClientList { get; set; }
        [NotMapped]
        public bool IsMLCOption { get; set; }
        [NotMapped]
        public bool IsISMOption { get; set; }
        [NotMapped]
        public bool IsISPSOption { get; set; }
        [NotMapped]
        public string PriceTypeName { get; set; }
        [NotMapped]
        public bool IsAmended { get; set; }

        #endregion
    }
}
