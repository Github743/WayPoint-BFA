using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    public partial class WorkOrderVesselClient
    {
        /// <summary>
        /// Get or Set the Official Number Property
        /// </summary>
        [NotMapped]
        public int? OfficialNumber { get; set; }

        /// <summary>
        /// Get or Set the Vessel Name Property
        /// </summary>
        [NotMapped]
        public string? VesselName { get; set; }

        /// <summary>
        /// Get or Set the IMO Number Property
        /// </summary>
        [NotMapped]
        public int? IMONumber { get; set; }

        /// <summary>
        /// Get or Set the Vessel Id Property
        /// </summary>
        [NotMapped]
        public int? VesselId { get; set; }

        /// <summary>
        /// Get or Set the Work Order Id Property
        /// </summary>
        [NotMapped]
        public int? WorkOrderId { get; set; }

        /// <summary>
        /// Get or Set the System Work Order Type Flow Id Property
        /// </summary>
        [NotMapped]
        public int? SystemWorkOrderTypeFlowId { get; set; }

        /// <summary>
        /// Get or Set the System Work Order Id Property
        /// </summary>
        [NotMapped]
        public int? SystemWorkOrderId { get; set; }

        /// <summary>
        /// Get or Set the Client Id property
        /// </summary>
        [NotMapped]        
        
        public int? ClientId { get; set; }

        /// <summary>
        /// Get or Set the Client Name property
        /// </summary>
        [NotMapped]
        public string? ClientName { get; set; }

        /// <summary>
        /// Get or Set the Department Role Id
        /// </summary>
        [NotMapped]
        public int? DepartmentRoleId { get; set; }

        /// <summary>
        /// Get or Set the Client Role 
        /// </summary>
        [NotMapped]
        public int? ClientRole { get; set; }

        /// <summary>
        /// Get or Set the Client Role Type
        /// </summary>
        [NotMapped]
        public int? ClientRoleType { get; set; }

        /// <summary>
        /// Get or Set the Entity Id Property
        /// </summary>
        [NotMapped]
        public int? EntityId { get; set; }

        /// <summary>
        /// Get or Set the Client Role Name Property
        /// </summary>
        [NotMapped]
        public string? ClientRoleName { get; set; }
        [NotMapped]
        public bool? RequirePrePayment { get; set; }



        /// <summary>
        /// Get or Set the Client Number property
        /// </summary>
        [NotMapped]
        public int? ClientNumber { get; set; }

        /// <summary>
        /// Get or Set the Client Type Name property
        /// </summary>
        [NotMapped]
        public string? ClientTypeName { get; set; }
        [NotMapped]
        public DateTime? EndDate { get; set; }
        [NotMapped]
        public string? CompanyIMONumber { get; set; }
        //public string ClientAddressAlpha3Code { get; set; }

    } // end class
}
