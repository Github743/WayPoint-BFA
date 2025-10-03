namespace WayPoint.Model
{
    public class WorkOrderCreationViewModel
    {
        public WorkOrderCreationViewModel()
        {
            Entities = [];
            UserId = null;
            ClientDetail = new ClientDetail();
            systemWorkOrder = new SystemWorkOrder();
        }

        public ClientDetail ClientDetail { get; set; }
        public int SystemWorkOrderId { get; set; }
        public int SystemWorkOrderFlowId { get; set; }
        public int SystemWorkOrderFlowStepId { get; set; }
        public int SystemWorkOrderTypeFlowId { get; set; }
        public DateTime? EstimatedClosingDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int? AssignedToId { get; set; }
        public List<Entity> Entities { get; set; }
        public bool IsLiscr { get; set; }
        public bool IsNonLiberianActivity { get; set; }
        public int? ImoNumber { get; set; }
        public string VesselName { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public int? ClientId { get; set; }
        public int? ClientNumber { get; set; } 
        public string IdentificationColumn { get; set; } = string.Empty;
        public int? VesselId { get; set; }
        public bool? IsNonLibFlagForView { get; set; }
        public int? OfficialNumber { get; set; }
        public SystemWorkOrder systemWorkOrder { get; set; }
        public string Office { get; set; } = string.Empty;
        public int? DispensationItemId { get; set; }
        public int MenuId { get; set; }
        public int HeaderMenuId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string CertificateName { get; set; } = string.Empty;        
        public bool IsCPExternalFlow { get; set; }
        public string ExternalRequestedBy { get; set; } = string.Empty;
    }
}
