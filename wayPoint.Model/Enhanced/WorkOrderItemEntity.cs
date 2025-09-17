namespace WayPoint.Model
{
    public partial class WorkOrderItemEntity
    {
        [DbIgnore]
        public int SystemWorkOrderXrefItemId { get; set; }

        [DbIgnore]
        public int SystemWorkOrderItemId { get; set; }

        [DbIgnore]
        public string? WorkOrderItemName { get; set; }

        [DbIgnore]
        public bool IsInvoice { get; set; }

        [DbIgnore]
        public int WorkOrderId { get; set; }

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
        public int EntityId { get; set; }

        [DbIgnore]
        public int SystemWorkOrderId { get; set; }

        [DbIgnore]
        public string? Acronym { get; set; }

        [DbIgnore]
        public string? ClientRole { get; set; }

        [DbIgnore]
        public int? Order { get; set; }

        [DbIgnore]
        public bool IsGenericItem { get; set; }

        [DbIgnore]
        public bool CanShow { get; set; }

        [DbIgnore]
        public bool UIReadonly { get; set; }

        [DbIgnore]
        public string? SystemWorkOrderItemDisplayNmae { get; set; }
    }
}
