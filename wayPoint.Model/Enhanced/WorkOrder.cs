namespace WayPoint.Model
{
    public partial class WorkOrder
    {
        [DbIgnore]
        public string WorkOrderName { get; set; } = string.Empty;
        [DbIgnore]
        public string DisplayName { get; set; } = string.Empty;
        [DbIgnore]
        public bool NonLiberianActivity { get; set; }
        [DbIgnore]
        public bool CorpContext { get; set; }
        [DbIgnore]
        public bool VesselContext { get; set; }
        [DbIgnore]
        public bool ClientContext { get; set; }
        [DbIgnore]
        public string SystemWorkOrderFlowStepName { get; set; } = string.Empty;
        [DbIgnore]
        public int? NextWorkFlowStepId { get; set; }
        [DbIgnore]
        public int SystemWorkOrderFlowId { get; set; }
        [DbIgnore]
        public string WorkOrderStatus { get; set; } = string.Empty;
        [DbIgnore]
        public string WorkOrderStatusDisplayName { get; set; } = string.Empty;
        [DbIgnore]
        public bool CanExternalAdvance { get; set; }
        [DbIgnore]
        public bool InternalReadOnlyMode { get; set; }
        [DbIgnore]
        public bool ExternalReadOnlyMode { get; set; }
        [DbIgnore]
        public string RequestedItems { get; set; } = string.Empty;
        [DbIgnore]
        public int? IMONumber { get; set; }
        [DbIgnore]
        public int? OfficialNumber { get; set; }
        [DbIgnore]
        public int? FlagState { get; set; }
        [DbIgnore]
        public bool IsDeletedDueToSanctions { get; set; } = false;
        [DbIgnore]
        public int? OrderSubmissionId { get; set; }
        [DbIgnore]
        public int? OrderSubmissionWorkOrderId { get; set; }
        [DbIgnore]
        public int? VesselId { get; set; }
        [DbIgnore]
        public string VesselName { get; set; } = string.Empty;
        [DbIgnore]
        public int DefaultBillToClientRole { get; set; }
        [DbIgnore]
        public bool IsInternal { get; set; }
        [DbIgnore]
        public int? WorkOrderVesselId { get; set; }
        [DbIgnore]
        public int? ClientId { get; set; }
        [DbIgnore]
        public string ClientName { get; set; } = string.Empty;
        [DbIgnore]
        public bool DoWorkOrderItemsExist { get; set; }
        [DbIgnore]
        public bool AllowThirdParty { get; set; }
        [DbIgnore]
        public int? CorporateId { get; set; }
        [DbIgnore]
        public string CorporateName { get; set; } = string.Empty;
        [DbIgnore]
        public bool IsRegistrationWorkOrder { get; set; }
        [DbIgnore]
        public bool? HasActiveCertificate { get; set; }
        [DbIgnore]
        public string WorkOrderClassName { get; set; } = string.Empty;
        [DbIgnore]
        public string ParentSystemWorkOrderName { get; set; } = string.Empty;
        [DbIgnore]
        public int StepName { get; set; }
        [DbIgnore]
        public int ClientNumber { get; set; }
        [DbIgnore]
        public string ControllerName { get; set; } = string.Empty;
        [DbIgnore]
        public string ActionName { get; set; } = string.Empty;
        [DbIgnore]
        public DateTime? RegistrationDate { get; set; }
        [DbIgnore]
        public DateTime? OriginalRegistrationDate { get; set; }
        [DbIgnore]
        public bool IsBillingWorkOrder { get; set; }
        [DbIgnore]
        public bool IsRegUI { get; set; }
        [DbIgnore]
        public bool AllowBulkActivity { get; set; }
        [DbIgnore]
        public bool PostClosingApplicable { get; set; }
        [DbIgnore]
        public bool IsReplaceWoCorpOrClientContext { get; set; }
        [DbIgnore]
        public bool ShowRefreshButton { get; set; }
        //public UserPermissionViewModel workOrderPermission { get; set; }
        [DbIgnore]
        public bool isReadOnly { get; set; }
        [DbIgnore]
        public bool isLiscr { get; set; }
        [DbIgnore]
        public bool InvoiceContext { get; set; }
        [DbIgnore]
        public bool HasCourier { get; set; }
        [DbIgnore]
        public string AssignedToUserName { get; set; } = string.Empty;
        [DbIgnore]
        public int SystemMenuId { get; set; }
        [DbIgnore]
        public int? CorporateRegistrationNumber { get; set; }
        [DbIgnore]
        public bool AllowExternalUser { get; set; }
        [DbIgnore]
        public bool IsComplianceCheckRequired { get; set; }
    }
}
