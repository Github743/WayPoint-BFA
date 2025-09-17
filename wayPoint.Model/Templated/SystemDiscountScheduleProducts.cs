using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class SystemDiscountScheduleProducts : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "meta.usp_";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the SystemDiscountScheduleProductId Property of SystemDiscountScheduleProducts
        /// SystemDiscountScheduleProductId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Schedule Product Id")]
        public int SystemDiscountScheduleProductId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountScheduleId Property of SystemDiscountScheduleProducts
        /// SystemDiscountScheduleId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Schedule Id")]
        public int SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the SystemProductId Property of SystemDiscountScheduleProducts
        /// SystemProductId is Not Nullable
        ///</summary>


        [DisplayName("System Product Id")]
        public int SystemProductId { get; set; }

        ///<summary>
        /// Get or Set the DiscountType Property of SystemDiscountScheduleProducts
        /// DiscountType is Nullable 
        ///</summary>


        [DisplayName("Discount Type")]
        public int? DiscountType { get; set; }

        ///<summary>
        /// Get or Set the Amount Property of SystemDiscountScheduleProducts
        /// Amount is Nullable 
        ///</summary>


        [DisplayName("Amount")]
        public decimal? Amount { get; set; }

        ///<summary>
        /// Get or Set the IsRecurrence Property of SystemDiscountScheduleProducts
        /// IsRecurrence is Not Nullable
        ///</summary>


        [DisplayName("Is Recurrence")]
        public bool IsRecurrence { get; set; }

        ///<summary>
        /// Get or Set the RecurrencePattern Property of SystemDiscountScheduleProducts
        /// RecurrencePattern is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Recurrence Pattern")]
        public string RecurrencePattern { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the IsActive Property of SystemDiscountScheduleProducts
        /// IsActive is Not Nullable
        ///</summary>


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        ///<summary>
        /// Get or Set the DefaultOrder Property of SystemDiscountScheduleProducts
        /// DefaultOrder is Nullable 
        ///</summary>


        [DisplayName("Default Order")]
        public int? DefaultOrder { get; set; }

        ///<summary>
        /// Get or Set the StartDateType Property of SystemDiscountScheduleProducts
        /// StartDateType is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Start Date Type")]
        public string StartDateType { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the ProductMappingLookup Property of SystemDiscountScheduleProducts
        /// ProductMappingLookup is Nullable 
        ///</summary>

        [DisplayName("Product Mapping Lookup")]
        public int? ProductMappingLookup { get; set; }

        ///<summary>
        /// Get or Set the IssueType Property of SystemDiscountScheduleProducts
        /// IssueType is Nullable 
        ///</summary>

        [DisplayName("Issue Type")]
        public int? IssueType { get; set; }
        #endregion
    }
}
