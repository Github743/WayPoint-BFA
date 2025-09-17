using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class Client : BaseModel
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
        /// Get or Set the ClientId Property of Client
        /// ClientId is Not Nullable
        ///</summary>


        [DisplayName("Client Id")]
        public int ClientId { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of Client
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the ClientName Property of Client
        /// ClientName is Not Nullable
        ///</summary>
        
        [StringLength(250)]
        [DisplayName("Client Name")]
        public string ClientName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ClientNumber Property of Client
        /// ClientNumber is Not Nullable
        ///</summary>


        [DisplayName("Client Number")]
        public int ClientNumber { get; set; }

        ///<summary>
        /// Get or Set the ClientBusinessType Property of Client
        /// ClientBusinessType is Not Nullable
        ///</summary>


        [DisplayName("Client Business Type")]
        public int ClientBusinessType { get; set; }

        ///<summary>
        /// Get or Set the Status Property of Client
        /// Status is Not Nullable
        ///</summary>


        [DisplayName("Status")]
        public int Status { get; set; }

        ///<summary>
        /// Get or Set the CompanyIMONumber Property of Client
        /// CompanyIMONumber is Nullable 
        ///</summary>

        [StringLength(10)]
        [DisplayName("Company IMO Number")]
        public string CompanyIMONumber { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the RequirePurchaseOrder Property of Client
        /// RequirePurchaseOrder is Not Nullable
        ///</summary>


        [DisplayName("Require Purchase Order")]
        public bool RequirePurchaseOrder { get; set; }

        ///<summary>
        /// Get or Set the WebAddress Property of Client
        /// WebAddress is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Web Address")]
        public string WebAddress { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the EnableCARUpload Property of Client
        /// EnableCARUpload is Not Nullable
        ///</summary>


        [DisplayName("Enable CAR Upload")]
        public bool EnableCARUpload { get; set; }

        ///<summary>
        /// Get or Set the RequirePrePayment Property of Client
        /// RequirePrePayment is Not Nullable
        ///</summary>


        [DisplayName("Require Pre Payment")]
        public bool RequirePrePayment { get; set; }

        ///<summary>
        /// Get or Set the ClientPromisedVesselsCount Property of Client
        /// ClientPromisedVesselsCount is Nullable 
        ///</summary>


        [DisplayName("Client Promised Vessels Count")]
        public int? ClientPromisedVesselsCount { get; set; }

        ///<summary>
        /// Get or Set the ClientLookup Property of Client
        /// ClientLookup is Not Nullable
        ///</summary>
        
        [StringLength(273)]
        [DisplayName("Client Lookup")]
        public string ClientLookup { get; set; } = string.Empty;

        [DisplayName("Is Client Sanctioned")]
        public bool IsClientSanctioned { get; set; }

        #endregion
    }
}
