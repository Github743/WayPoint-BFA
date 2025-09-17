using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class SystemDiscountScheduleProducts
    {
        #region Properties

        /// <summary>
        /// Get or Set Discount Type Name Property
        /// </summary>
        public string DiscountTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set System Product Name Property
        /// </summary>
        public string SystemProductName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set System Product Amount Property
        /// </summary>
        public decimal? SystemProductAmount { get; set; }

        /// <summary>
        /// Get or Set System Discount Schedule Name Property
        /// </summary>
        public string SystemDiscountScheduleName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Product Code Property
        /// </summary>
        public string ProductCode { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set IsCustomized Property
        /// </summary>
        public bool IsCustomized { get; set; }

        /// <summary>
        /// Get or Set Product Mapping Lookup Name Property
        /// </summary>
        public string ProductMappingLookupName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Issue Type Name Property
        /// </summary>
        public string IssueTypeName { get; set; } = string.Empty;

        #endregion
    }
}
