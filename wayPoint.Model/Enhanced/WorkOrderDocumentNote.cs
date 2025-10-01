using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderDocumentNote
    {
        [Required]
        [StringLength(4096)]
        [DisplayName("Note")]
        public string Text { get; set; }
    }
}
