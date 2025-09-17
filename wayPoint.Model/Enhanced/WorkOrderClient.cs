namespace WayPoint.Model
{
    public partial class WorkOrderClient
    {
        [DbIgnore]
        public string StatusName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set the BusinessTypeName property
        /// </summary>
        [DbIgnore]
        public string BusinessTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set the ShortName property
        /// </summary>
        [DbIgnore]
        public string ShortName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set the ClientRole property
        /// </summary>
        [DbIgnore]
        public string ClientRole { get; set; } = string.Empty;

        [DbIgnore]
        public string SystemWorkOrderName { get; set; } = string.Empty;

        [DbIgnore]
        public string SystemWorkOrderItemName { get; set; } = string.Empty;

        [DbIgnore]
        public int WorkOrderId { get; set; }

        [DbIgnore]
        public int WorkOrderItemEntityId { get; set; }

        [DbIgnore]
        public string WorkOrderStatus { get; set; } = string.Empty;

        [DbIgnore]
        public int EntityId { get; set; }
    }
}
