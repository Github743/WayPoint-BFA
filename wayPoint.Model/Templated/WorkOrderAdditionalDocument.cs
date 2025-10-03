using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderAdditionalDocument
    {
        public int WorkOrderItemId { get; set; }

        public int WorkOrderEntityId { get; set; }

        public int WorkOrderId { get; set; }

        public byte[] DocumentByteArray { get; set; }

        public string EntityName { get; set; }

        public string ItemName { get; set; }

        public bool IsLISCRUser { get; set; }

        public string DocumentType { get; set; }

        public string FileExtension { get; set; }
    }
}
