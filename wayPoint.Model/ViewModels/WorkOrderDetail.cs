namespace WayPoint.Model
{
    public class WorkOrderDetail : BaseModel
    {
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        }

        public int WorkOrderId { get; set; }
        public int SystemWorkOrderId { get; set; }
        public string WorkOrderName { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string Office { get; set; } = string.Empty;
        public int ClientNumber { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Total { get; set; }
    }
}
