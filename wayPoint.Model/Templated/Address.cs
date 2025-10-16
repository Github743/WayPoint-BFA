using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class Address : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "FN.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of Address
        ///</summary>
        public int Id { get { return AddressId; } set { AddressId = value; } }

        ///<summary>
        /// Get or Set the AddressId Property of Address
        /// AddressId is Not Nullable
        ///</summary>


        [DisplayName("Address Id")]
        public int AddressId { get; set; }

        ///<summary>
        /// Get or Set the Address1 Property of Address
        /// Address1 is Not Nullable
        ///</summary>
        [Required]
        [StringLength(250)]
        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        ///<summary>
        /// Get or Set the Address2 Property of Address
        /// Address2 is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Address 2")]
        public string Address2 { get; set; }

        ///<summary>
        /// Get or Set the Address3 Property of Address
        /// Address3 is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Address 3")]
        public string Address3 { get; set; }

        ///<summary>
        /// Get or Set the Address4 Property of Address
        /// Address4 is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("Address 4")]
        public string Address4 { get; set; }

        ///<summary>
        /// Get or Set the City Property of Address
        /// City is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("City")]
        public string City { get; set; }

        ///<summary>
        /// Get or Set the County Property of Address
        /// County is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("County")]
        public string County { get; set; }

        ///<summary>
        /// Get or Set the Province Property of Address
        /// Province is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Province")]
        public string Province { get; set; }

        ///<summary>
        /// Get or Set the State Property of Address
        /// State is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("State")]
        public string State { get; set; }

        ///<summary>
        /// Get or Set the PostalCode Property of Address
        /// PostalCode is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        ///<summary>
        /// Get or Set the CountryId Property of Address
        /// CountryId is Not Nullable
        ///</summary>


        [DisplayName("Country Id")]
        public int CountryId { get; set; }

        #endregion
    }
}
