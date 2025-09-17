namespace WayPoint.Model
{
    public partial class WorkOrderItem
    {
        [DbIgnore]
        public int SystemWorkOrderItemId { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemName { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemDescription { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemDetailLoadActionName { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemDetailLoadControllerName { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemDetailSaveMethodName { get; set; }
        
        [DbIgnore]
        public bool IsInvoice { get; set; }
        
        [DbIgnore]
        public bool IsGenericItem { get; set; }

        [DbIgnore]
        public int? SystemOptionId { get; set; }

        [DbIgnore]
        public int? SystemWorkOrderItemOrder { get; set; }

        [DbIgnore]
        public bool UIReadonly { get; set; }

        [DbIgnore]
        public string? Acronym { get; set; }

        [DbIgnore]
        public bool CanShow { get; set; }

        [DbIgnore]
        public string? SystemWOItemDisplayName { get; set; }
    }
}
