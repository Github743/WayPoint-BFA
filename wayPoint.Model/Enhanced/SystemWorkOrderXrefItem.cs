namespace WayPoint.Model
{
    public partial class SystemWorkOrderXrefItem
    {

        public string OptionName { get; set; }= string.Empty;
        public string OptionDescription { get; set; } = string.Empty;
        public bool IsInvoice { get; set; }
        public string Acronym { get; set; } = string.Empty;
        public string SystemWorkOrderItemName { get; set; } = string.Empty;
    }
}
