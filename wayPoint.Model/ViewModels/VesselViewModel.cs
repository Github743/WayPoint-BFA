using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.ViewModels
{
    public class VesselViewModel : BaseModel
    {
        public VesselViewModel()
        {
            vessel = new Vessel();
            lVesselOwner = new List<VesselOwner>();
            VesselOwner = new VesselOwner();
            lVesselClient = new List<VesselClient>();
            VesselClient = new VesselClient();
            VesselInspectionMonitoring = new VesselInspectionMonitoring();
            VesselInspectionDue = new VesselInspectionDue();
        }
        public Vessel vessel { get; set; }
        public List<VesselOwner> lVesselOwner { get; set; }
        public VesselClient VesselClient { get; set; }
        public List<VesselClient> lVesselClient { get; set; }
        public VesselOwner VesselOwner { get; set; }
        public List<VesselContact> lVesselContact { get; set; }
        public List<VesselNameHistory> lVesselNameHistory { get; set; }
        public List<EntityNote> lEntityNote { get; set; }
        public VesselInspectionDetails VesselInspectionDetails { get; set; }
        public int? Age { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("OUTSTANDING BALANCE")]
        public double? OutstandingBalance { get; set; }
        public int? ClientId { get; set; }
        public bool? IsLiscr { get; set; }
        public bool? IsNonLibFlag { get; set; }
        public int menuId { get; set; }
        public int headerMenuId { get; set; }
        public bool IsExcludeFormerName { get; set; }
        /// <summary>
        /// Get or Set the Entity Email Property
        /// </summary>
        public List<EntityEmail> lEntityEmail { get; set; }
        public int NextSystemWorkOrderId { get; set; }

        public VesselInspectionMonitoring VesselInspectionMonitoring { get; set; }

        public VesselInspectionDue VesselInspectionDue { get; set; }

        public bool IsInspectionManagerRole { get; set; }

        public string LRITTestExpirationDate { get; set; }
        public string LastFlagStateDetentionDate { get; set; }
        [DisplayName("Vessel Sanctioned Date")]
        public string VesselSanctionedDate { get; set; }

    }//end class
    public class VesselInspectionDetails
    {
        public VesselInspectionDetails()
        {
            PSCInspectionDetails = new VesselPSCInspectionDetails();
        }
        public DateTime? ASIDueDate { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        //public int LastInspectionDeficiencyCount { get; set; }

        public string IHMCategory { get; set; }
        public string IHMInspectionType { get; set; }
        public DateTime? IHMDate { get; set; }
        public DateTime? IHMExpiryDate { get; set; }
        public string IHMFriendlyString
        {
            get
            {
                string result = "";
                if (IHMDate.HasValue) //&& (IHMInspectionType == ApplicationConstants.INSPECTION_TYPE_INTIAL || IHMCategory == ApplicationConstants.INSPECTION_TYPE_RENEWAL)
                {
                    result = IHMInspectionType + ": " + IHMDate.Value.ToString("dd-MMM-yyyy") + (IHMExpiryDate != null ? (" - " + IHMExpiryDate.Value.ToString("dd-MMM-yyyy")) : "") + (!string.IsNullOrEmpty(IHMIssuedByName) ? " - Issued By: " + IHMIssuedByName : string.Empty);
                }
                return result;
            }
        }

        public string SMCCategory { get; set; }
        public DateTime? SMCDate { get; set; }
        public DateTime? SMCExpiryDate { get; set; }
        public bool SMCIntermediateVerification { get; set; }
        public string SMCFriendlyString
        {
            get
            {
                string result = "";
                if (SMCDate.HasValue && (SMCCategory == ApplicationConstants.INSPECTION_TYPE_INTERIM || SMCCategory == ApplicationConstants.INSPECTION_TYPE_INTIAL || SMCCategory == ApplicationConstants.INSPECTION_TYPE_RENEWAL || SMCCategory == ApplicationConstants.INSPECTION_CERT_TYPE || SMCCategory == ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE))
                {
                    if (SMCCategory == ApplicationConstants.INSPECTION_CERT_TYPE && SMCIntermediateVerification)
                        SMCCategory = ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE;

                    result = SMCCategory + ": " + SMCDate.Value.ToString("dd-MMM-yyyy") + (SMCExpiryDate != null ? (" - " + SMCExpiryDate.Value.ToString("dd-MMM-yyyy")) : "") + (!string.IsNullOrEmpty(SMCIssuedByName) ? " - Issued By: " + SMCIssuedByName : string.Empty); ;
                }
                return result;
            }
        }
        public string ISSCCategory { get; set; }
        public DateTime? ISSCDate { get; set; }
        public DateTime? ISSCExpiryDate { get; set; }

        public bool ISSCIntermediateVerification { get; set; }
        public string ISSCFriendlyString
        {
            get
            {
                //string result = ISSCCategory + " - Date: "; 

                //if (ISSCDate.HasValue)
                //    result += ISSCDate.Value.ToString("dd-MMM-yyyy");
                string result = "";
                if (ISSCDate.HasValue && (ISSCCategory == ApplicationConstants.INSPECTION_TYPE_INTERIM || ISSCCategory == ApplicationConstants.INSPECTION_TYPE_INTIAL || ISSCCategory == ApplicationConstants.INSPECTION_TYPE_RENEWAL || ISSCCategory == ApplicationConstants.INSPECTION_CERT_TYPE || ISSCCategory == ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE))
                {
                    if (ISSCCategory == ApplicationConstants.INSPECTION_CERT_TYPE && ISSCIntermediateVerification)
                        ISSCCategory = ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE;

                    result = ISSCCategory + ": " + ISSCDate.Value.ToString("dd-MMM-yyyy") + (ISSCExpiryDate != null ? (" - " + ISSCExpiryDate.Value.ToString("dd-MMM-yyyy")) : "") + (!string.IsNullOrEmpty(ISSCIssuedByName) ? " - Issued By: " + ISSCIssuedByName : string.Empty); ;
                }

                return result;
            }
        }

        public string MLCCategory { get; set; }
        public DateTime? MLCDate { get; set; }
        public DateTime? MLCExpiryDate { get; set; }
        public bool MLCIntermediateVerification { get; set; }
        public string MLCFriendlyString
        {
            get
            {
                string result = "";
                if (MLCDate.HasValue && (MLCCategory == ApplicationConstants.INSPECTION_TYPE_INTERIM || MLCCategory == ApplicationConstants.INSPECTION_TYPE_INTIAL || MLCCategory == ApplicationConstants.INSPECTION_TYPE_RENEWAL || MLCCategory == ApplicationConstants.INSPECTION_CERT_TYPE || MLCCategory == ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE))
                {
                    if (MLCCategory == ApplicationConstants.INSPECTION_CERT_TYPE && MLCIntermediateVerification)
                        MLCCategory = ApplicationConstants.INSPECTION_TYPE_INTERMEDIATE;
                    result = MLCCategory + ": " + MLCDate.Value.ToString("dd-MMM-yyyy") + (MLCExpiryDate != null ? (" - " + MLCExpiryDate.Value.ToString("dd-MMM-yyyy")) : "") + (!string.IsNullOrEmpty(MLCIssuedByName) ? " - Issued By: " + MLCIssuedByName : string.Empty);
                }
                return result;
            }
        }

        public DateTime? IBWMCIssueDate { get; set; }
        public DateTime? IBWMCExpiryDate { get; set; }
        public string IBWMCCategory { get; set; }
        public string IBWMCFriendlyName
        {
            get
            {
                string result = IBWMCCategory + (IBWMCIssueDate != null ? (": " + IBWMCIssueDate.Value.ToString("dd-MMM-yyyy")) : "") + (IBWMCExpiryDate != null ? (" - " + IBWMCExpiryDate.Value.ToString("dd-MMM-yyyy")) : "");
                return result;
            }
        }

        public string IHMIssuedByName { get; set; }
        public string SMCIssuedByName { get; set; }
        public string ISSCIssuedByName { get; set; }
        public string MLCIssuedByName { get; set; }
        public VesselPSCInspectionDetails PSCInspectionDetails { get; set; }
    }
    public class VesselPSCInspectionDetails
    {
        public DateTime? LastPSCInspectionDate { get; set; }

        public string LatestPSCJurisdiction { get; set; }

        public int LastPSCInspectionDeficiencyCount { get; set; }

        public double NumberOfDetentionsOverall { get; set; }

        public double DeficiencyRateOverall { get; set; }

        public string LastPSCInspectionFriendlyString
        {
            get
            {
                string result = "";

                result = (LastPSCInspectionDate.HasValue ? LastPSCInspectionDate.Value.ToString("dd-MMM-yyyy") + " - " : "") + LatestPSCJurisdiction + " - " + LastPSCInspectionDeficiencyCount;

                return result;
            }
        }
        public string VesselWatchType { get; set; }
    }
}
