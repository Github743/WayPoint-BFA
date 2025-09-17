using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class SystemDiscountProgram : BaseModel
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
        /// Get or Set the SystemDiscountProgramId Property of SystemDiscountProgram
        /// SystemDiscountProgramId is Not Nullable
        ///</summary>


        [DisplayName("System Discount Program Id")]
        public int SystemDiscountProgramId { get; set; }

        ///<summary>
        /// Get or Set the Name Property of SystemDiscountProgram
        /// Name is Not Nullable
        ///</summary>
        [Required]
        [StringLength(150)]
        [DisplayName("Name")]
        public string? Name { get; set; }

        ///<summary>
        /// Get or Set the ContextType Property of SystemDiscountProgram
        /// ContextType is Not Nullable
        ///</summary>
        [Required]
        [StringLength(30)]
        [DisplayName("Context Type")]
        public string? ContextType { get; set; }

        ///<summary>
        /// Get or Set the AppliedType Property of SystemDiscountProgram
        /// AppliedType is Not Nullable
        ///</summary>
        [Required]
        [StringLength(30)]
        [DisplayName("Applied Type")]
        public string? AppliedType { get; set; }

        ///<summary>
        /// Get or Set the DiscountProgramRefObjectType Property of SystemDiscountProgram
        /// DiscountProgramRefObjectType is Nullable 
        ///</summary>

        [StringLength(30)]
        [DisplayName("Discount Program Ref Object Type")]
        public string? DiscountProgramRefObjectType { get; set; }

        #endregion
    }
}
