using System.ComponentModel;

namespace WayPoint.Model
{
    public partial class OrderShipment
    {
        public string ShipmentTypeName { get; set; }

        public string WebLink { get; set; }
        public int? OrderSubmissionId { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsInternalWorkOrder { get; set; }

        [DisplayName("Courier Provider")]
        public string CourierName { get; set; }

        public string CourierWebLink { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public string Province { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public int? CountryId { get; set; }

        public string CountryFullName { get; set; }

        public string CountryShortName { get; set; }

        public string CountryAlpha3Code { get; set; }

        public string AddressFormatted { get; set; }

        public string SystemWorkOrderName { get; set; }
        public int MaximumEmailAddress { get; set; }

        public bool HasEdelivery { get; set; }

        public bool HasCourier { get; set; }
    }
}
