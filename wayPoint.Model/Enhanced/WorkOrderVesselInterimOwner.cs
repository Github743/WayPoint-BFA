using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.Enhanced
{
    public partial class WorkOrderVesselInterimOwner
    {

        //public string VesselOwnerName { get; set; }
        public int WorkOrderId { get; set; }
        public string TypeName { get; set; }
        public bool IsChildWO { get; set; }
        public string WorkOrderItemName { get; set; }
    }
}
