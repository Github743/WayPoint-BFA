using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class Address
    {
        public int EntityId { get; set; }
        public int EntityAddressType { get; set; }

        /// <summary>
        /// Get or Sets the Country Short Name Property
        /// </summary>
        public string CountryShortName { get; set; }

        /// <summary>
        /// Get or Set the country Full Name Property
        /// </summary>
        public string CountryFullName { get; set; }

        /// <summary>
        /// Get or Set the Apha 3 code property
        /// </summary>
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Get or Set the Numerical Code property
        /// </summary>
        public int? NumericalCode { get; set; }

        /// <summary>
        /// Get or Set the Address Formatted Property
        /// </summary>
        public string AddressFormatted { get; set; }

        public int InspectionId { get; set; }

    }
}
