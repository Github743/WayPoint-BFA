using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class OrderShipment : BaseModel
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
        /// Get or Set the Id property of OrderShipment
        ///</summary>
        public int Id { get { return OrderShipmentId; } set { OrderShipmentId = value; } }

        ///<summary>
        /// Get or Set the OrderShipmentId Property of OrderShipment
        /// OrderShipmentId is Not Nullable
        ///</summary>


        [DisplayName("Order Shipment Id")]
        public int OrderShipmentId { get; set; }

        ///<summary>
        /// Get or Set the WorkOrderId Property of OrderShipment
        /// WorkOrderId is Not Nullable
        ///</summary>


        [DisplayName("Work Order Id")]
        public int WorkOrderId { get; set; }

        ///<summary>
        /// Get or Set the IsCourier Property of OrderShipment
        /// IsCourier is Not Nullable
        ///</summary>


        [DisplayName("Is Courier")]
        public bool IsCourier { get; set; }

        ///<summary>
        /// Get or Set the IsEdelivery Property of OrderShipment
        /// IsEdelivery is Not Nullable
        ///</summary>


        [DisplayName("Is Edelivery")]
        public bool IsEdelivery { get; set; }

        ///<summary>
        /// Get or Set the CourierProviderId Property of OrderShipment
        /// CourierProviderId is Nullable 
        ///</summary>


        [DisplayName("Courier Provider Id")]
        public int? CourierProviderId { get; set; }

        ///<summary>
        /// Get or Set the TrackingNumber Property of OrderShipment
        /// TrackingNumber is Nullable 
        ///</summary>

        [StringLength(100)]
        [DisplayName("Tracking Number")]
        public string TrackingNumber { get; set; }

        ///<summary>
        /// Get or Set the ShipDate Property of OrderShipment
        /// ShipDate is Nullable 
        ///</summary>


        [DisplayName("Ship Date")]
        public DateTime? ShipDate { get; set; }

        ///<summary>
        /// Get or Set the Name Property of OrderShipment
        /// Name is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Name")]
        public string Name { get; set; }

        ///<summary>
        /// Get or Set the PhoneNumber Property of OrderShipment
        /// PhoneNumber is Nullable 
        ///</summary>

        [StringLength(50)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        ///<summary>
        /// Get or Set the EmailAddress Property of OrderShipment
        /// EmailAddress is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        ///<summary>
        /// Get or Set the ShippingAddressId Property of OrderShipment
        /// ShippingAddressId is Nullable 
        ///</summary>


        [DisplayName("Shipping Address Id")]
        public int? ShippingAddressId { get; set; }

        ///<summary>
        /// Get or Set the EdeliveryEmailAddress Property of OrderShipment
        /// EdeliveryEmailAddress is Nullable 
        ///</summary>

        [StringLength(150)]
        [DisplayName("Edelivery Email Address")]
        public string EdeliveryEmailAddress { get; set; }

        ///<summary>
        /// Get or Set the CompanyName Property of OrderShipment
        /// CompanyName is Nullable 
        ///</summary>

        [StringLength(200)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        ///<summary>
        /// Get or Set the CCEmailAddress Property of OrderShipment
        /// CCEmailAddress is Nullable 
        ///</summary>

        [StringLength(400)]
        [DisplayName("CC Email Address")]
        public string CCEmailAddress { get; set; }


        [StringLength(400)]
        [DisplayName("Billing Email Address")]
        public string BillingEmailAddress { get; set; }

        #endregion
    }
}
