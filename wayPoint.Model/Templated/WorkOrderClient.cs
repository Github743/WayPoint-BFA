using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderClient : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the WorkOrderClientId Property of WorkOrderClient
        /// WorkOrderClientId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Client Id")]
        public int WorkOrderClientId { get; set; }

        ///<summary>
        /// Get or Set the ClientId Property of WorkOrderClient
        /// ClientId is Not Nullable
        ///</summary>


        [DisplayName("Client Id")]
        public int ClientId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderEntityId Property of WorkOrderClient
        /// WorkOrderEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Entity Id")]
        public int WorkOrderEntityId { get; set; }

        ///<summary>
        /// Get or Set the ClientName Property of WorkOrderClient
        /// ClientName is Not Nullable
        ///</summary>
        
        [StringLength(250)]
        [DisplayName("Client Name")]
        public string ClientName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ClientNumber Property of WorkOrderClient
        /// ClientNumber is Not Nullable
        ///</summary>


        [DisplayName("Client Number")]
        public int ClientNumber { get; set; }

        ///<summary>
        /// Get or Set the ClientBusinessType Property of WorkOrderClient
        /// ClientBusinessType is Not Nullable
        ///</summary>


        [DisplayName("Client Business Type")]
        public int ClientBusinessType { get; set; }

        ///<summary>
        /// Get or Set the Status Property of WorkOrderClient
        /// Status is Not Nullable
        ///</summary>


        [DisplayName("Status")]
        public int Status { get; set; }

        ///<summary>
        /// Get or Set the CompanyIMONumber Property of WorkOrderClient
        /// CompanyIMONumber is Nullable 
        ///</summary>

        [StringLength(10)]
        [DisplayName("Company IMO Number")]
        public string CompanyIMONumber { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the RequirePurchaseOrder Property of WorkOrderClient
        /// RequirePurchaseOrder is Not Nullable
        ///</summary>


        [DisplayName("Require Purchase Order")]
        public bool RequirePurchaseOrder { get; set; }

        ///<summary>
        /// Get or Set the WebAddress Property of WorkOrderClient
        /// WebAddress is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Web Address")]
        public string WebAddress { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the RequirePrePayment Property of WorkOrderClient
        /// RequirePrePayment is Not Nullable
        ///</summary>


        [DisplayName("Require Pre Payment")]
        public bool RequirePrePayment { get; set; }

        #endregion
    }
}
