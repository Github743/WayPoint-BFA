using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class WorkOrderVesselOwner
    {
        public int? AddressId { get; set; }
        [DisplayName("Address 1")]
        [Required(ErrorMessage = "Please enter Address1")]
        public string Address1 { get; set; }
        [DisplayName("Address 2")]
        public string Address2 { get; set; }
        [DisplayName("Address 3")]
        public string Address3 { get; set; }
        [DisplayName("Address 4")]
        public string Address4 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Province { get; set; }
        public string State { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        [Required(ErrorMessage = "Select Country")]
        public int? CountryId { get; set; }
        public string ShortName { get; set; }
        public int? NumericalCode { get; set; }
        public int? CorporateEntityId { get; set; }
        public string Alpha3Code { get; set; }
        public string AddressFormatted
        {
            get
            {
                var address = new StringBuilder();
                address.Append((!string.IsNullOrEmpty(Address1) && Address1 != "null") ? Address1 + "\n" : "");
                address.Append((!string.IsNullOrEmpty(Address2) && Address2 != "null") ? Address2 + "\n" : "");
                address.Append((!string.IsNullOrEmpty(Address3) && Address3 != "null") ? Address3 + "\n" : "");
                address.Append((!string.IsNullOrEmpty(Address4) && Address4 != "null") ? Address4 + "\n" : "");
                address.Append((!string.IsNullOrEmpty(City) && City != "null") ? City + ", " : "");
                address.Append((!string.IsNullOrEmpty(State) && State != "null") ? State + "\n" : "");
                address.Append((!string.IsNullOrEmpty(PostalCode) && PostalCode != "null") ? PostalCode + "\n" : "");
                address.Append(!string.IsNullOrEmpty(ShortName) ? ShortName : "");
                return address.ToString();
            }
            set { }
        }
        public int? EntityAddressType { get; set; }
        public string EntityAddressTypeName { get; set; }
        public bool Liberianflag { get; set; }
        public string Country { get; set; }
        public int WorkOrderId { get; set; }
        public int? VesselId { get; set; }

        public DateTime? EndDate { get; set; }

        public int? LegacyCorpId { get; set; }

        //public int? OfficialNumber { get; set; }

        public string CorpOwnerIMONumber { get; set; }

        public string CorpRegistrationNumber { get; set; }

        public int? CorporateRegistrationNumber { get; set; }

        public int VesselIMONumber { get; set; }

        public string CorporateName { get; set; }

        //public string FMEPrincipalAddressCountry { get; set; } 
        public string CorporateStatus { get; set; }
        public string CorpStatusVerifyMsgForRegWO { get; set; }

        public VesselOwner UpdateVesselOwnerDetails(VesselOwner vesselOwner)
        {
            vesselOwner.CorporateId = CorporateId;
            vesselOwner.EntityAddressId = EntityAddressId;
            vesselOwner.VesselOwnerName = VesselOwnerName;
            vesselOwner.IsFME = IsFME;
            vesselOwner.Proportion = Proportion;
            vesselOwner.Citizenship = Citizenship;

            return vesselOwner;
        }

        public VesselOwner GetNewVesselOwner()
        {
            VesselOwner vesselOwner = new VesselOwner() { FromDate = DateTime.Now };
            return UpdateVesselOwnerDetails(vesselOwner);
        }
    }
}
