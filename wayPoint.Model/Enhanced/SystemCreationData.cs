namespace WayPoint.Model
{
    public class SystemCreationData
    {
        public SystemCreationData()
        {
            SystemWorkOrder = new SystemWorkOrder();
            WorkOrder = new WorkOrder();
            //WorkOrderSettings = new List<SystemWorkOrderXrefSetting>();
            //SettingFields = new List<SystemWorkOrderSettingField>();
            //KeyMap = new List<SystemWorkOrderDataModelKeyMap>();
            //AcceptableStatuses = new List<SystemWorkOrderEntityStatus>();
            AppliedItems = new List<SystemWorkOrderXrefItem>();
            //SystemWorkOrderApprovals = new List<SystemWorkOrderApprovalXrefFlowStep>();
            //SystemWorkOrderProduct = new List<Models.SystemWorkOrderProduct>();
            //workOrderSettingFields = new List<WorkOrderSettingField>();

        }

        public SystemWorkOrder SystemWorkOrder { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public List<SystemWorkOrderXrefItem> AppliedItems { get; set; }
    }
}
