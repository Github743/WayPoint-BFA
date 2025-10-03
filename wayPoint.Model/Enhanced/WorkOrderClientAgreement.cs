namespace WayPoint.Model
{
    public partial class WorkOrderClientAgreement
    {
        #region Properties

        /// <summary>
        /// Get or Set System Discount Program Name Property
        /// </summary>
        [DbIgnore]
        public string SystemDiscountProgramName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set System Discount Program Type Id Property
        /// </summary>
        [DbIgnore]
        public int? SystemDiscountProgramTypeId { get; set; }

        /// <summary>
        /// Get or Set Client Entity Id Property
        /// </summary>
        [DbIgnore]
        public int? ClientEntityId { get; set; }

        /// <summary>
        /// Get or Set Approved By Name Property
        /// </summary>
        [DbIgnore]
        public string ApprovedByName { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set WorkOrderId Property
        /// </summary>
        [DbIgnore]
        public int WorkOrderId { get; set; }
        #endregion
    }
}
