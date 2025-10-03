using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderEmail
    {
        // Fn.EmailEvent - Start
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Name { get; set; }
        public DateTime SentDate { get; set; }

        // All the files coming from WorkorderEmail will be 
        // identified by stream_id
        public Guid? Stream_Id { get; set; }

        public string BCC { get; set; }
    }
}
