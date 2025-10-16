using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model
{
    public partial class VesselOwner
    {
        [DisplayName("Vessel Owner Name")]
        [Required]
        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "{0} cannot exceed 250 characters")]
        public string OwnerName { get; set; }
        [Required]
        public int? AddressId { get; set; }
        [Required]
        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "{0} cannot exceed 250 characters")]
        public string Address1 { get; set; }
        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "{0} cannot exceed 250 characters")]
        public string Address2 { get; set; }
        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "{0} cannot exceed 250 characters")]
        public string Address3 { get; set; }
        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "{0} cannot exceed 250 characters")]
        public string Address4 { get; set; }
        [Required]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public string City { get; set; }
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public string County { get; set; }
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public string Province { get; set; }
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public string State { get; set; }
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        [Required]
        public int? CountryId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int? NumericalCode { get; set; }
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

        public string RegistrationNumber { get; set; }

        public int? CorporateRegistrationNumber { get; set; }
        public string OwnerImoNumber { get; set; }
        public string Domicile { get; set; }
        public string CorpStatus { get; set; }

        /// <summary>
        /// get or set the lis corp id property
        /// </summary>
        public int? lisCorpId { get; set; }
        /// <summary>
        /// get or sets the vessel owner id from lis
        /// </summary>
        public int? lisVessselOwnerId { get; set; }

        /// <summary>
        /// Try to copy the values from VesselOwner to Work order vessel owner table
        /// </summary>
        /// <returns></returns>
        public WorkOrderVesselOwner GetWorkOrderVesselOwner()
        {
            WorkOrderVesselOwner workOrderVesselOwner = new WorkOrderVesselOwner()
            {
                CorporateId = CorporateId,
                EntityAddressId = EntityAddressId,
                IsFME = IsFME,
                Citizenship = Citizenship,
                Proportion = Proportion,
                Residence = Residence
            };

            if (VesselOwnerId == -1)
                workOrderVesselOwner.VesselOwnerId = null;
            else
                workOrderVesselOwner.VesselOwnerId = VesselOwnerId;

            return workOrderVesselOwner;
        }

        /// <summary>
        /// Takes the address information in this model and converts it to an Address object.
        /// </summary>
        /// <returns></returns>
        public Address GetWorkOrderVesselOwnerAddress()
        {
            Address address = new Address()
            {
                Address1 = Address1,
                Address2 = Address2,
                Address3 = Address3,
                Address4 = Address4,
                City = City,
                State = State,
                Province = Province,
                PostalCode = PostalCode,
                NumericalCode = NumericalCode,
                Alpha3Code = Alpha3Code,
                CountryId = Convert.ToInt32(CountryId),
                County = County,
                EntityAddressType = Convert.ToInt32(EntityAddressType),
                AddressId = Convert.ToInt32(AddressId),
                AddressFormatted = AddressFormatted
            };

            return address;
        }

        [Required]
        public int CorporateType { get; set; }
        public string CorpTypeName { get; set; }
        //removed as there are no ref to the prop - and removed also from the SP 
        //public string FMEPrincipalAddressCountry { get; set; }

        public int VesselIMONumber { get; set; }
    }
}
