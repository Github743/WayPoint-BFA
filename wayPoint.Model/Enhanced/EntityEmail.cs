using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class EntityEmail
    {
        /// <summary>
        /// gets or sets the Email address property
        /// </summary>
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please enter Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,15}$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// gets or sets the Email type name property
        /// </summary>
        public string EmailTypeName { get; set; }
        public string EmailTypeDisplayName { get; set; }

        [DisplayName("Email Type")]
        [Required(ErrorMessage = "Please select Email Type")]
        public Lookup SelectedEmailType { get; set; }

        public string EntityIdList { get; set; }
    }
}
