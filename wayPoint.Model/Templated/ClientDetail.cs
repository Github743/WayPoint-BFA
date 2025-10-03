using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class ClientDetail : BaseModel
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
        /// Get or Set the ClientId Property of ClientDetail
        /// ClientId is Not Nullable
        ///</summary>


        [DisplayName("Client Id")]
        public int ClientId { get; set; }

        ///<summary>
        /// Get or Set the ClientName Property of ClientDetail
        /// ClientName is Not Nullable
        ///</summary>
        
        [StringLength(250)]
        [DisplayName("Client Name")]
        public string? ClientName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ClientNumber Property of ClientDetail
        /// ClientNumber is Not Nullable
        ///</summary>


        [DisplayName("Client Number")]
        public int ClientNumber { get; set; }

        ///<summary>
        /// Get or Set the Address Property of ClientDetail
        /// Address is Not Nullable
        ///</summary>
        
        [StringLength(752)]
        [DisplayName("Address")]
        public string? Address { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the City Property of ClientDetail
        /// City is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("City")]
        public string? City { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the County Property of ClientDetail
        /// County is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("County")]
        public string County { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the State Property of ClientDetail
        /// State is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("State")]
        public string? State { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Province Property of ClientDetail
        /// Province is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Province")]
        public string? Province { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the PostalCode Property of ClientDetail
        /// PostalCode is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Country Property of ClientDetail
        /// Country is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Country")]
        public string? Country { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the PhoneNumber Property of ClientDetail
        /// PhoneNumber is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the EmailAddress Property of ClientDetail
        /// EmailAddress is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Email Address")]
        public string? EmailAddress { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the CompanyIMONumber Property of ClientDetail
        /// CompanyIMONumber is Nullable 
        ///</summary>

        [StringLength(10)]
        [DisplayName("Company IMO Number")]
        public string? CompanyIMONumber { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Type Property of ClientDetail
        /// Type is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Type")]
        public string? Type { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Fax Property of ClientDetail
        /// Fax is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Fax")]
        public string? Fax { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the WebAddress Property of ClientDetail
        /// WebAddress is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Web Address")]
        public string? WebAddress { get; set; } = string.Empty;


        [DisplayName("Create Date")]
        public DateTime? CreateDate { get; set; }

        ///<summary>
        /// Get or Set the BusinessDivision Property of ClientDetail
        /// BusinessDivision is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Business Division")]
        public string? BusinessDivision { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Status Property of ClientDetail
        /// Status is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Status")]
        public string? Status { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the AddressType Property of ClientDetail
        /// AddressType is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Address Type")]
        public string? AddressType { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the IsPartOfOwningGroup Property of ClientDetail
        /// IsPartOfOwningGroup is Nullable 
        ///</summary>


        [DisplayName("Is Part Of Owning Group")]
        public bool? IsPartOfOwningGroup { get; set; }

        ///<summary>
        /// Get or Set the OGClientName Property of ClientDetail
        /// OGClientName is Nullable 
        ///</summary>

        [StringLength(250)]
        [DisplayName("OG Client Name")]
        public string? OGClientName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the OGClientNumber Property of ClientDetail
        /// OGClientNumber is Nullable 
        ///</summary>


        [DisplayName("OG Client Number")]
        public int? OGClientNumber { get; set; }

        ///<summary>
        /// Get or Set the OGClientId Property of ClientDetail
        /// OGClientId is Nullable 
        ///</summary>


        [DisplayName("OG Client Id")]
        public int? OGClientId { get; set; }
        public bool IsClientSanctioned { get; set; }
        #endregion
    }
}
