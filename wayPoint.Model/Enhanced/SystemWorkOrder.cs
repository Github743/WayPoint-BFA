using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class SystemWorkOrder
    {
        [DisplayName("Business Department Name")]
        public string BusinessDepartmentName { get; set; } = string.Empty;

        public string BusinessDivisionName { get; set; } = string.Empty;
    }
}
