namespace WayPoint.Model
{
    public partial class WorkOrderVesselClient
    {
        /// <summary>
        /// Get or Set the Official Number Property
        /// </summary>
        public int? OfficialNumber { get; set; }

        /// <summary>
        /// Get or Set the Vessel Name Property
        /// </summary>
        public string? VesselName { get; set; }

        /// <summary>
        /// Get or Set the IMO Number Property
        /// </summary>
        public int? IMONumber { get; set; }

        /// <summary>
        /// Get or Set the Vessel Id Property
        /// </summary>
        public int? VesselId { get; set; }

        /// <summary>
        /// Get or Set the Work Order Id Property
        /// </summary>
        public int? WorkOrderId { get; set; }

        /// <summary>
        /// Get or Set the System Work Order Type Flow Id Property
        /// </summary>
        public int? SystemWorkOrderTypeFlowId { get; set; }

        /// <summary>
        /// Get or Set the System Work Order Id Property
        /// </summary>
        public int? SystemWorkOrderId { get; set; }

        /// <summary>
        /// Get or Set the Client Id property
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Get or Set the Client Name property
        /// </summary>
        public string? ClientName { get; set; }

        /// <summary>
        /// Get or Set the Department Role Id
        /// </summary>
        public int? DepartmentRoleId { get; set; }

        /// <summary>
        /// Get or Set the Client Role 
        /// </summary>
        public int? ClientRole { get; set; }

        /// <summary>
        /// Get or Set the Client Role Type
        /// </summary>
        public int? ClientRoleType { get; set; }

        /// <summary>
        /// Get or Set the Entity Id Property
        /// </summary>
        public int? EntityId { get; set; }

        /// <summary>
        /// Get or Set the Client Role Name Property
        /// </summary>
        public string? ClientRoleName { get; set; }

        public bool? RequirePrePayment { get; set; }



        /// <summary>
        /// Get or Set the Client Number property
        /// </summary>
        public int? ClientNumber { get; set; }

        /// <summary>
        /// Get or Set the Client Type Name property
        /// </summary>
        public string? ClientTypeName { get; set; }

        public DateTime? EndDate { get; set; }

        public string? CompanyIMONumber { get; set; }
        //public string ClientAddressAlpha3Code { get; set; }

    } // end class
}
