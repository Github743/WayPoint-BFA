using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class SystemWorkOrderDocument
    {
        /// <summary>
        /// Get or Sets the Work Order Document Name Property
        /// </summary>
        public string Name { get; set; }
        public bool CanExternalUploadOrDelete { get; set; }

        public bool CanUndated { get; set; }
        public bool ConsiderConfirmation { get; set; }

        public string DisplayName { get; set; }

    }
}
