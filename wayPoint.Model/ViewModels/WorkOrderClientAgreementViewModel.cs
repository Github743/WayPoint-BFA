using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.ViewModels
{
    public class WorkOrderClientAgreementViewModel
    {
        public WorkOrderClientAgreementViewModel()
        {
            WorkOrderClientAgreement = new WorkOrderClientAgreement();
            lWorkOrderClientAgreementEntity = new List<WorkOrderClientAgreementEntity>();
            WorkOrderClientAgreementEntityProduct = new WorkOrderClientAgreementEntityProduct();

        }
        public WorkOrderClientAgreement WorkOrderClientAgreement { get; set; }
        public WorkOrderClientAgreementEntityProduct WorkOrderClientAgreementEntityProduct { get; set; }
        public List<WorkOrderClientAgreementEntity> lWorkOrderClientAgreementEntity { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsLiscrUser { get; set; }
        public int WorkOrderId { get; set; }
        public string WorkOrderStatus { get; set; }
        public WorkOrder workOrder { get; set; }

    }
} 
