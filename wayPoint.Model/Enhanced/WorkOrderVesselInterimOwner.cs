namespace WayPoint.Model
{
    public partial class WorkOrderVesselInterimOwner
    {

        //public string VesselOwnerName { get; set; }
        public int WorkOrderId { get; set; }
        public string? TypeName { get; set; }
        public bool IsChildWO { get; set; }
        public string? WorkOrderItemName { get; set; }
    }
}
