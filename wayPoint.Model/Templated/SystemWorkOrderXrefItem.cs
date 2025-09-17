using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WayPoint.Model
{
    public partial class SystemWorkOrderXrefItem : BaseModel
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
        /// Get or Set the SystemWorkOrderXrefItemId Property of SystemWorkOrderXrefItem
        /// SystemWorkOrderXrefItemId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Xref Item Id")]
        public int SystemWorkOrderXrefItemId { get; set; }

        ///<summary>
        /// Get or Set the Optional Property of SystemWorkOrderXrefItem
        /// Optional is Not Nullable
        ///</summary>


        [DisplayName("Optional")]
        public bool Optional { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderId Property of SystemWorkOrderXrefItem
        /// SystemWorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Id")]
        public int SystemWorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the SystemWorkOrderItemId Property of SystemWorkOrderXrefItem
        /// SystemWorkOrderItemId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Item Id")]
        public int SystemWorkOrderItemId { get; set; }

        ///<summary>
        /// Get or Set the SystemOptionId Property of SystemWorkOrderXrefItem
        /// SystemOptionId is Nullable 
        ///</summary>


        [DisplayName("System Option Id")]
        public int? SystemOptionId { get; set; }

        ///<summary>
        /// Get or Set the IsGenericItem Property of SystemWorkOrderXrefItem
        /// IsGenericItem is Not Nullable
        ///</summary>


        [DisplayName("Is Generic Item")]
        public bool IsGenericItem { get; set; }

        ///<summary>
        /// Get or Set the HasBusinessRules Property of SystemWorkOrderXrefItem
        /// HasBusinessRules is Not Nullable
        ///</summary>


        [DisplayName("Has Business Rules")]
        public bool HasBusinessRules { get; set; }

        ///<summary>
        /// Get or Set the CanShow Property of SystemWorkOrderXrefItem
        /// IsGenericItem is Not Nullable
        ///</summary>


        [DisplayName("Is Generic Item")]
        public bool CanShow { get; set; }

        ///<summary>
        /// Get or Set the UIReadonly Property of SystemWorkOrderXrefItem
        /// UIReadonly is Not Nullable
        ///</summary>

        [DisplayName("UI Readonly")]
        public bool UIReadonly { get; set; }



        #endregion
    }
}
