using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class WorkOrderDocumentNote
    {
        [Required]
        [StringLength(4096)]
        [DisplayName("Note")]
        public string? Text { get; set; }
    }
}
