using System.ComponentModel.DataAnnotations.Schema;

namespace WayPoint.Model
{
    public partial class WorkOrderClientAgreementEntityProduct
    {
        #region Properties

        /// <summary>
        /// Get or Set Discount Type Name Property
        /// </summary>
        [DbIgnore]
        [NotMapped]
        public string? DiscountTypeName { get; set; }

        /// <summary>
        /// Get or Set System Product Name Property
        /// </summary>
        [DbIgnore]
        [NotMapped]
        public string? SystemProductName { get; set; }


        /// <summary>
        /// Get or Set System Product Amount Property
        /// </summary>
        [DbIgnore]
        [NotMapped]
        public decimal? SystemProductAmount { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleId Property 
        /// SystemDiscountScheduleId is Nullable 
        ///</summary>
        [DbIgnore]
        [NotMapped]
        public int? SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleName Property 
        ///</summary>
        [DbIgnore]
        [NotMapped]
        public string? SystemDiscountScheduleName { get; set; }

        /////<summary>
        ///// Get or Set the DefaultOrder Property 
        ///// DefaultOrder is Nullable 
        /////</summary>
        //public int? DefaultOrder { get; set; }

        /// <summary>
        /// Get or Set System Discount Program Type Id Property
        /// </summary>
        [DbIgnore]
        [NotMapped]
        public int? SystemDiscountProgramTypeId { get; set; }

        /// <summary>
        /// Get or Set Entity Id Property
        /// </summary>
        [DbIgnore]
        [NotMapped]
        public int? EntityId { get; set; }

        [DbIgnore]
        [NotMapped]
        public string? ProductCode { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? ProductGroupTypeId { get; set; }

        [DbIgnore]
        [NotMapped]
        public int? TonnageBillingReference { get; set; }
        
        #endregion
    }
}
