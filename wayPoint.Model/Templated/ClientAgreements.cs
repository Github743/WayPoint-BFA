using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class ClientAgreements : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "FN";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of ClientAgreements
        ///</summary>
        public int Id { get { return ClientAgreementId; } set { ClientAgreementId = value; } }

        ///<summary>
        /// Get or Set the ClientAgreementId Property of ClientAgreements
        /// ClientAgreementId is Not Nullable
        ///</summary>


        [DisplayName("Client Agreement Id")]
        public int ClientAgreementId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountProgramTypeId Property of ClientAgreements
        /// SystemDiscountProgramTypeId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Program Type Id")]
        public int SystemDiscountProgramTypeId { get; set; }

        ///<summary>
        /// Get or Set the ClientId Property of ClientAgreements
        /// ClientId is Not Nullable
        ///</summary>


        [DisplayName("Client Id")]
        public int ClientId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleId Property of ClientAgreements
        /// SystemDiscountScheduleId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Schedule Id")]
        public int SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the AgreementDate Property of ClientAgreements
        /// AgreementDate is Nullable 
        ///</summary>


        [DisplayName("Agreement Date")]
        public DateTime? AgreementDate { get; set; }

        ///<summary>
        /// Get or Set the SignedDate Property of ClientAgreements
        /// SignedDate is Nullable 
        ///</summary>


        [DisplayName("Signed Date")]
        public DateTime? SignedDate { get; set; }

        ///<summary>
        /// Get or Set the AmendmentDate Property of ClientAgreements
        /// AmendmentDate is Nullable 
        ///</summary>


        [DisplayName("Amendment Date")]
        public DateTime? AmendmentDate { get; set; }

        ///<summary>
        /// Get or Set the TerminationDate Property of ClientAgreements
        /// TerminationDate is Nullable 
        ///</summary>


        [DisplayName("Termination Date")]
        public DateTime? TerminationDate { get; set; }

        ///<summary>
        /// Get or Set the IsMLCOption Property of ClientAgreements
        /// IsMLCOption is Not Nullable
        ///</summary>


        [DisplayName("Is MLC Option")]
        public bool IsMLCOption { get; set; }

        ///<summary>
        /// Get or Set the IsISMOption Property of ClientAgreements
        /// IsISMOption is Not Nullable
        ///</summary>


        [DisplayName("Is ISM Option")]
        public bool IsISMOption { get; set; }

        ///<summary>
        /// Get or Set the IsISPSOption Property of ClientAgreements
        /// IsISPSOption is Not Nullable
        ///</summary>


        [DisplayName("Is ISPS Option")]
        public bool IsISPSOption { get; set; }

        ///<summary>
        /// Get or Set the HasAdditionalDiscounts Property of ClientAgreements
        /// HasAdditionalDiscounts is Not Nullable
        ///</summary>


        [DisplayName("Has Additional Discounts")]
        public bool HasAdditionalDiscounts { get; set; }

        ///<summary>
        /// Get or Set the EnrollmentDate Property of ClientAgreements
        /// EnrollmentDate is Nullable 
        ///</summary>


        [DisplayName("Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }

        ///<summary>
        /// Get or Set the CreateIntialInvoice Property of ClientAgreements
        /// CreateIntialInvoice is Not Nullable
        ///</summary>


        [DisplayName("Create Intial Invoice")]
        public bool CreateIntialInvoice { get; set; }

        ///<summary>
        /// Get or Set the ConsolidatedStatement Property of ClientAgreements
        /// ConsolidatedStatement is Not Nullable
        ///</summary>


        [DisplayName("Consolidated Statement")]
        public bool ConsolidatedStatement { get; set; }

        ///<summary>
        /// Get or Set the AgreementText Property of ClientAgreements
        /// AgreementText is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Agreement Text")]
        public string AgreementText { get; set; }

        ///<summary>
        /// Get or Set the AppendixText Property of ClientAgreements
        /// AppendixText is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Appendix Text")]
        public string AppendixText { get; set; }

        ///<summary>
        /// Get or Set the TerminationReason Property of ClientAgreements
        /// TerminationReason is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Termination Reason")]
        public string TerminationReason { get; set; }

        ///<summary>
        /// Get or Set the Status Property of ClientAgreements
        /// Status is Nullable 
        ///</summary>


        [DisplayName("Status")]
        public int? Status { get; set; }

        ///<summary>
        /// Get or Set the Proposal Date Property of ClientAgreements
        /// Status is Nullable 
        ///</summary>
        [DisplayName("Proposal Date")]
        public DateTime? ProposalDate { get; set; }

        ///<summary>
        /// Get or Set the Accepted By Property of ClientAgreements
        /// Status is Nullable 
        ///</summary>
        [DisplayName("Accepted By")]
        public string AcceptedBy { get; set; }

        ///<summary>
        /// Get or Set the Approved By Property of ClientAgreements
        /// Status is Nullable 
        ///</summary>
        [DisplayName("Approved By")]
        public int? ApprovedBy { get; set; }

        ///<summary>
        /// Get or Set the Submitted By Property of ClientAgreements
        /// Status is Nullable 
        ///</summary>
        [DisplayName("Submitted By")]
        public string SubmittedBy { get; set; }
        #endregion
    }
}
