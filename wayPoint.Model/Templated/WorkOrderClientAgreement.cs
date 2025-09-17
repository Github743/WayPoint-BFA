using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class WorkOrderClientAgreement : BaseModel
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
        /// Get or Set the WorkOrderClientAgreementId Property of WorkOrderClientAgreement
        /// WorkOrderClientAgreementId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Client Agreement Id")]
        public int WorkOrderClientAgreementId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderClientAgreement
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the ClientId Property of WorkOrderClientAgreement
        /// ClientId is Not Nullable
        ///</summary>


        [DisplayName("Client Id")]
        public int? ClientId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountProgramId Property of WorkOrderClientAgreement
        /// SystemDiscountProgramId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Program Id")]
        public int SystemDiscountProgramId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleId Property of WorkOrderClientAgreement
        /// SystemDiscountScheduleId is Nullable 
        ///</summary>


        [DisplayName("System Discount Schedule Id")]
        public int? SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the AgreementDate Property of WorkOrderClientAgreement
        /// AgreementDate is Nullable 
        ///</summary>


        [DisplayName("Agreement Date")]
        public DateTime? AgreementDate { get; set; }

        ///<summary>
        /// Get or Set the SignedDate Property of WorkOrderClientAgreement
        /// SignedDate is Nullable 
        ///</summary>


        [DisplayName("Signed Date")]
        public DateTime? SignedDate { get; set; }

        ///<summary>
        /// Get or Set the AmendmentDate Property of WorkOrderClientAgreement
        /// AmendmentDate is Nullable 
        ///</summary>


        [DisplayName("Amendment Date")]
        public DateTime? AmendmentDate { get; set; }

        ///<summary>
        /// Get or Set the TerminationDate Property of WorkOrderClientAgreement
        /// TerminationDate is Nullable 
        ///</summary>


        [DisplayName("Termination Date")]
        public DateTime? TerminationDate { get; set; }

        ///<summary>
        /// Get or Set the IsMLCOption Property of WorkOrderClientAgreement
        /// IsMLCOption is Not Nullable
        ///</summary>


        [DisplayName("Is MLC Option")]
        public bool IsMLCOption { get; set; }

        ///<summary>
        /// Get or Set the IsISMOption Property of WorkOrderClientAgreement
        /// IsISMOption is Not Nullable
        ///</summary>


        [DisplayName("Is ISM Option")]
        public bool IsISMOption { get; set; }

        ///<summary>
        /// Get or Set the IsISPSOption Property of WorkOrderClientAgreement
        /// IsISPSOption is Not Nullable
        ///</summary>


        [DisplayName("Is ISPS Option")]
        public bool IsISPSOption { get; set; }

        ///<summary>
        /// Get or Set the HasAdditionalDiscounts Property of WorkOrderClientAgreement
        /// HasAdditionalDiscounts is Not Nullable
        ///</summary>


        [DisplayName("Has Additional Discounts")]
        public bool HasAdditionalDiscounts { get; set; }

        ///<summary>
        /// Get or Set the EnrollmentDate Property of WorkOrderClientAgreement
        /// EnrollmentDate is Nullable 
        ///</summary>


        [DisplayName("Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }

        ///<summary>
        /// Get or Set the CreateIntialInvoice Property of WorkOrderClientAgreement
        /// CreateIntialInvoice is Not Nullable
        ///</summary>


        [DisplayName("Create Intial Invoice")]
        public bool CreateIntialInvoice { get; set; }

        ///<summary>
        /// Get or Set the ConsolidatedStatement Property of WorkOrderClientAgreement
        /// ConsolidatedStatement is Not Nullable
        ///</summary>


        [DisplayName("Consolidated Statement")]
        public bool ConsolidatedStatement { get; set; }

        ///<summary>
        /// Get or Set the AgreementText Property of WorkOrderClientAgreement
        /// AgreementText is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Agreement Text")]
        public string? AgreementText { get; set; } 

        ///<summary>
        /// Get or Set the AppendixText Property of WorkOrderClientAgreement
        /// AppendixText is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Appendix Text")]
        public string? AppendixText { get; set; } 

        ///<summary>
        /// Get or Set the TerminationReason Property of WorkOrderClientAgreement
        /// TerminationReason is Nullable 
        ///</summary>

        [StringLength(4096)]
        [DisplayName("Termination Reason")]
        public string? TerminationReason { get; set; } 

        ///<summary>
        /// Get or Set the IsSignedAndReceived Property of WorkOrderClientAgreement
        /// IsSignedAndReceived is Not Nullable
        ///</summary>


        [DisplayName("Is Signed And Received")]
        public bool IsSignedAndReceived { get; set; }

        [DisplayName("Proposal Date")]
        public DateTime? ProposalDate { get; set; }

        [DisplayName("Accepted By")]
        public string? AcceptedBy { get; set; } 

        [DisplayName("Approved By")]
        public int? ApprovedBy { get; set; }

        [DisplayName("Submitted By")]
        public string? SubmittedBy { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderName { get; set; }
        [DbIgnore]
        public string? WorkOrderStatus { get; set; } 

        #endregion
    }
}
