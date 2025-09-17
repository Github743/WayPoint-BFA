namespace WayPoint.Model
{
    public class WorkOrderSearchRequest
    {
        public int? WorkOrderId { get; set; }
        public string? WorkOrderName { get; set; } 
        public string? Status { get; set; } 
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
