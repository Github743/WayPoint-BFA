using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.ViewModels
{
    [Keyless]
    public class VesselReservedNameViewModel
    {
        public VesselReservedNameViewModel()
        {
            //lEntityReservedNames = new List<EntityReservedName>();
            VesselName = string.Empty;
            VesselOldName = string.Empty;
            //WorkOrderRegistrationDetail = new WorkOrderRegistrationDetail();
        }

        [DisplayName("Vessel Name")]
        public string VesselName { get; set; }

        public int? EntityReservedNameId { get; set; }

        public bool IsNameChange { get; set; }
        //public List<EntityReservedName> lEntityReservedNames { get; set; }
        public int? IMONumber { get; set; }
        public string VesselOldName { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
