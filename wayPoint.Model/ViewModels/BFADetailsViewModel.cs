using System.ComponentModel;

namespace WayPoint.Model
{
    public class BFADetailsViewModel
    {
        public bool IsMLCOption { get; set; }

        public bool IsISMOption { get; set; }

        public bool IsISPSOption { get; set; }

        [DisplayName("Enrollment Date")]
        public string? EnrollmentDate { get; set; }

        [DisplayName("Amendment Date")]
        public string? AmendmentDate { get; set; }

        [DisplayName("Create Intial Invoice")]
        public bool CreateIntialInvoice { get; set; }

        [DisplayName("Consolidated Statement")]
        public bool ConsolidatedStatement { get; set; }

        [DisplayName("Agreement Text")]
        public string? AgreementText { get; set; }

        [DisplayName("Appendix Text")]
        public string? AppendixText { get; set; }

        public bool HasAdditionalDiscounts { get; set; }

        public int WorkOrderId { get; set; }

        public int WorkOrderClientAgreementId { get; set; }

        public bool IsLISCRUser { get; set; }
        public string? WorkOrderName { get; set; }

        public WorkOrderSettingField? WorkOrderSettingField { get; set; }

        public bool ReadOnlyMode { get; set; }
        public string? ClientName { get; set; }
    }

    public class KeyValueDto
    {
        public string? ColumnName { get; set; }
        public object? Value { get; set; }
    }
}
