using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
        public partial class WorkOrderDocumentDetail
        {
            public string Status { get; set; }
            public int EntityId { get; set; }

            [Required]
            [StringLength(4096)]
            [DisplayName("Note")]
            public string Text { get; set; }
            public int WorkOrderApprovalId { get; set; }
            public int NoteId { get; set; }
            public bool IsCustomReGenerate { get; set; }
            public string VesselName { get; set; }
            public bool CanShowForExternal { get; set; }
            public bool IsLiscr { get; set; }
            public bool IsInvoice { get; set; }
        }
    }
