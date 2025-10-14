using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class ClientAgreementEntities : BaseModel
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
        /// Get or Set the Id property of ClientAgreementEntities
        ///</summary>
        public int Id { get { return ClientAgreementEntityId; } set { ClientAgreementEntityId = value; } }

        ///<summary>
        /// Get or Set the ClientAgreementEntityId Property of ClientAgreementEntities
        /// ClientAgreementEntityId is Not Nullable
        ///</summary>


        [DisplayName("Client Agreement Entity Id")]
        public int ClientAgreementEntityId { get; set; }

        ///<summary>
        /// Get or Set the ClientAgreementId Property of ClientAgreementEntities
        /// ClientAgreementId is Not Nullable
        ///</summary>


        [DisplayName("Client Agreement Id")]
        public int ClientAgreementId { get; set; }

        ///<summary>
        /// Get or Set the EntityId Property of ClientAgreementEntities
        /// EntityId is Not Nullable
        ///</summary>


        [DisplayName("Entity Id")]
        public int EntityId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleId Property of ClientAgreementEntities
        /// SystemDiscountScheduleId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Schedule Id")]
        public int SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the EnrollmentDate Property of ClientAgreementEntities
        /// EnrollmentDate is Nullable 
        ///</summary>


        [DisplayName("Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }

        ///<summary>
        /// Get or Set the AnniversaryDate Property of ClientAgreementEntities
        /// AnniversaryDate is Nullable 
        ///</summary>


        [DisplayName("Anniversary Date")]
        public DateTime? AnniversaryDate { get; set; }

        ///<summary>
        /// Get or Set the BillingCycleCounter Property of ClientAgreementEntities
        /// BillingCycleCounter is Nullable 
        ///</summary>


        [DisplayName("Billing Cycle Counter")]
        public int? BillingCycleCounter { get; set; }

        ///<summary>
        /// Get or Set the OriginalAnniversaryYear Property of ClientAgreementEntities
        /// OriginalAnniversaryYear is Nullable 
        ///</summary>


        [DisplayName("Original Anniversary Year")]
        public int? OriginalAnniversaryYear { get; set; }

        ///<summary>
        /// Get or Set the IsCustomFees Property of ClientAgreementEntities
        /// IsCustomFees is Not Nullable
        ///</summary>


        [DisplayName("Is Custom Fees")]
        public bool IsCustomFees { get; set; }

        ///<summary>
        /// Get or Set the BillToClient Property of ClientAgreementEntities
        /// BillToClient is Nullable 
        ///</summary>


        [DisplayName("Bill To Client")]
        public int? BillToClient { get; set; }


        ///<summary>
        /// Get or Set the NoJoiningInvoice Property of ClientAgreementEntities
        /// NoJoiningInvoice is Not Nullable
        ///</summary>


        [DisplayName("No Joining Invoice")]
        public bool NoJoiningInvoice { get; set; }

        ///<summary>
        /// Get or Set the TonnageCap Property of ClientAgreementEntities
        /// TonnageCap is  Nullable
        ///</summary>


        [DisplayName("Tonnage Cap")]
        public float? TonnageCap { get; set; }

        ///<summary>
        /// Get or Set the TonnageTaxPriceModel Property of ClientAgreementEntities
        /// TonnageTaxPriceModel is  Nullable
        ///</summary>


        [DisplayName("Tonnage Tax Price Model")]
        public int? TonnageTaxPriceModel { get; set; }


        ///<summary>
        /// Get or Set the IsVessel Property of ClientAgreementEntities
        /// IsVessel is Not Nullable
        ///</summary>


        [DisplayName("Is Vessel")]
        public bool IsVessel { get; set; }

        #endregion
    }
}
