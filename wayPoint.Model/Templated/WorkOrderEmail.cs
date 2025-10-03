using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{ 
    public partial class WorkOrderEmail : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO.usp_";
            }
        } // end of schema name property 


        ///<summary>
        /// Get or Set the SystemWorkOrderEmailId Property of WorkOrderEmail
        /// SystemWorkOrderEmailId is Not Nullable
        ///</summary>


        [DisplayName("System Work Order Email Id")]
        public int SystemWorkOrderEmailId { get; set; }

        ///<summary>
        /// Get or Set the EmailEventId Property of WorkOrderEmail
        /// EmailEventId is Not Nullable
        ///</summary>


        [DisplayName("Email Event Id")]
        public int EmailEventId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of WorkOrderEmail
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }
        ///<summary>
        /// Get or Set the Id property of WorkOrderEmail
        ///</summary>
        public int Id { get { return WorkOrderEmailId; } set { WorkOrderEmailId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderEmailId Property of WorkOrderEmail
        /// WorkOrderEmailId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Email Id")]
        public int WorkOrderEmailId { get; set; }

        #endregion
    }
}
