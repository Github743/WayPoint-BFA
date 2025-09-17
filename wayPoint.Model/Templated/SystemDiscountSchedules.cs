using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WayPoint.Model
{
    public partial class SystemDiscountSchedules : BaseModel
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
        /// Get or Set the SystemDiscountScheduleId Property of SystemDiscountSchedules
        /// SystemDiscountScheduleId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Schedule Id")]
        public int SystemDiscountScheduleId { get; set; }

        ///<summary>
        /// Get or Set the SystemDiscountProgramTypeId Property of SystemDiscountSchedules
        /// SystemDiscountProgramTypeId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Program Type Id")]
        public int SystemDiscountProgramTypeId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of SystemDiscountSchedules
        /// Name is Not Nullable
        ///</summary>
        
        [StringLength(300)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the DisplayName Property of SystemDiscountSchedules
        /// DisplayName is Not Nullable
        ///</summary>
        
        [StringLength(200)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the Description Property of SystemDiscountSchedules
        /// Description is Nullable 
        ///</summary>

        [StringLength(300)]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        ///<summary>
        /// Get or Set the DefaultOrder Property of SystemDiscountSchedules
        /// DefaultOrder is Nullable 
        ///</summary>


        [DisplayName("Default Order")]
        public int? DefaultOrder { get; set; }

        #endregion
    }
}
