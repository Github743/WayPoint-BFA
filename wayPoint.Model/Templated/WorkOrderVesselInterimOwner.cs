using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderVesselInterimOwner : BaseModel
    {
        #region Properties

        ///<summary>
        /// returns the schema name of the table
        ///</summary>
        public override string SchemaName
        {
            get
            {
                return "WO";
            }
        } // end of schema name property 

        ///<summary>
        /// Get or Set the Id property of WorkOrderVesselInterimOwner
        ///</summary>
        public int Id { get { return WorkOrderVesselInterimOwnerId; } set { WorkOrderVesselInterimOwnerId = value; } }

        ///<summary>
        /// Get or Set the WorkOrderVesselInterimOwnerId Property of WorkOrderVesselInterimOwner
        /// WorkOrderVesselInterimOwnerId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Vessel Interim Owner Id")]
        public int WorkOrderVesselInterimOwnerId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderItemEntityId Property of WorkOrderVesselInterimOwner
        /// WorkOrderItemEntityId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Item Entity Id")]
        public int WorkOrderItemEntityId { get; set; }

        ///<summary>
        /// Get or Set the Type Property of WorkOrderVesselInterimOwner
        /// Type is Not Nullable
        ///</summary>


        [DisplayName("Type")]
        public int Type { get; set; }

        ///<summary>
        /// Get or Set the OwnerName Property of WorkOrderVesselInterimOwner
        /// OwnerName is Not Nullable
        ///</summary>

        [StringLength(250)]
        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }

        ///<summary>
        /// Get or Set the Sequence Property of WorkOrderVesselInterimOwner
        /// Sequence is Nullable 
        ///</summary>


        [DisplayName("Sequence")]
        public int? Sequence { get; set; }

        ///<summary>
        /// Get or Set the Proportion Property of WorkOrderVesselInterimOwner
        /// Proportion is Not Nullable
        ///</summary>


        [DisplayName("Proportion")]
        public double? Proportion { get; set; }


        public bool IsInvoice { get; set; } = false;

        #endregion
    }
}
