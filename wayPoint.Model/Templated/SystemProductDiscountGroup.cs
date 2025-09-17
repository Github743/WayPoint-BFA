using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class SystemProductDiscountGroup : BaseModel
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
        /// Get or Set the SystemProductDiscountGroupId Property of SystemProductDiscountGroup
        /// SystemProductDiscountGroupId is Not Nullable
        ///</summary>


        [DisplayName("System Product Discount Group Id")]
        public int SystemProductDiscountGroupId { get; set; }

        ///<summary>
        /// Get or Set the ProductGroup Property of SystemProductDiscountGroup
        /// ProductGroup is Not Nullable
        ///</summary>


        [DisplayName("Product Group")]
        public int ProductGroup { get; set; }

        ///<summary>
        /// Get or Set the SystemProductId Property of SystemProductDiscountGroup
        /// SystemProductId is Not Nullable
        ///</summary>


        [DisplayName("System Product Id")]
        public int SystemProductId { get; set; }

        #endregion
    }
}
