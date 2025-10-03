using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class SystemWorkOrderGroup
    {
        [DbIgnore]
        public string SystemGroupName { get; set; }
    }
}
