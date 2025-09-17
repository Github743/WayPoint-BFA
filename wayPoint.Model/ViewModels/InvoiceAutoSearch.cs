namespace WayPoint.Model
{
    public class InvoiceAutoSearch
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; }
        public bool CorpContext { get; set; }
        public bool VesselContext { get; set; }
        public bool ClientContext { get; set; }
        public string ClientNumber { get; set; } = string.Empty;
        public string OfficialNumber { get; set; } = string.Empty;
        public string CorporateId { get; set; } = string.Empty;
        public bool IsInvoiceCanceled { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public bool IsInvoiceItems { get; set; }
    }
}
