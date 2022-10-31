using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetMerchantDataUpdateRequestBeforeApprovalModelInput : BaseClass
    {
        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }
    }

    public class GetMerchantDataUpdateRequestBeforeApprovalModelOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("MerchantTypeId")]
        [DataMember]
        public Int32 MerchantTypeId { get; set; }


        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }


        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }


        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public Int64 MappedMerchantId { get; set; }


        [JsonProperty("DealerMobileNo")]
        [DataMember]
        public string DealerMobileNo { get; set; }


        [JsonProperty("OutletCategoryId")]
        [DataMember]
        public Int32 OutletCategoryId { get; set; }


        [JsonProperty("OutletCategoryName")]
        [DataMember]
        public string OutletCategoryName { get; set; }


        [JsonProperty("HighwayNo1")]
        [DataMember]
        public string HighwayNo1 { get; set; }


        [JsonProperty("HighwayNo2")]
        [DataMember]
        public string HighwayNo2 { get; set; }



        [JsonProperty("HighwayName")]
        [DataMember]
        public string HighwayName { get; set; }



        [JsonProperty("SBUTypeId")]
        [DataMember]
        public Int32 SBUTypeId { get; set; }


        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }



        [JsonProperty("LPGCNGSale")]
        [DataMember]
        public decimal? LPGCNGSale { get; set; }



        [JsonProperty("PancardNumber")]
        [DataMember]
        public string PancardNumber { get; set; }




        [JsonProperty("GSTNumber")]
        [DataMember]
        public string GSTNumber { get; set; }



        [JsonProperty("RetailOutletAddress1")]
        [DataMember]
        public string RetailOutletAddress1 { get; set; }



        [JsonProperty("RetailOutletAddress2")]
        [DataMember]
        public string RetailOutletAddress2 { get; set; }



        [JsonProperty("RetailOutletAddress3")]
        [DataMember]
        public string RetailOutletAddress3 { get; set; }



        [JsonProperty("RetailOutletLocation")]
        [DataMember]
        public string RetailOutletLocation { get; set; }



        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }



        [JsonProperty("RetailOutletStateId")]
        [DataMember]
        public Int32 RetailOutletStateId { get; set; }


        [JsonProperty("RetailOutletStateName")]
        [DataMember]
        public string RetailOutletStateName { get; set; }



        [JsonProperty("RetailOutletDistrictId")]
        [DataMember]
        public Int32 RetailOutletDistrictId { get; set; }


        [JsonProperty("RetailOutletDistrictName")]
        [DataMember]
        public string RetailOutletDistrictName { get; set; }


        [JsonProperty("RetailOutletPinNumber")]
        [DataMember]
        public string RetailOutletPinNumber { get; set; }



        [JsonProperty("RetailOutletPhoneNumber")]
        [DataMember]
        public string RetailOutletPhoneNumber { get; set; }



        [JsonProperty("RetailOutletFax")]
        [DataMember]
        public string RetailOutletFax { get; set; }



        [JsonProperty("ZonalOfficeId")]
        [DataMember]
        public Int32 ZonalOfficeId { get; set; }


        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }



        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }



        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }



        [JsonProperty("SalesAreaId")]
        [DataMember]
        public Int32 SalesAreaId { get; set; }


        [JsonProperty("SalesAreaName")]
        [DataMember]
        public string SalesAreaName { get; set; }



        [JsonProperty("ContactPersonNameFirstName")]
        [DataMember]
        public string ContactPersonNameFirstName { get; set; }



        [JsonProperty("ContactPersonNameMiddleName")]
        [DataMember]
        public string ContactPersonNameMiddleName { get; set; }


        [JsonProperty("ContactPersonNameLastName")]
        [DataMember]
        public string ContactPersonNameLastName { get; set; }


        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }



        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }


        [JsonProperty("Mics")]
        [DataMember]
        public string Mics { get; set; }


        [JsonProperty("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }


        [JsonProperty("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }


        [JsonProperty("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }


        [JsonProperty("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }


        [JsonProperty("CommunicationCity")]
        [DataMember]
        public string CommunicationCity { get; set; }


        [JsonProperty("CommunicationStateId")]
        [DataMember]
        public Int32 CommunicationStateId { get; set; }


        [JsonProperty("CommunicationStateName")]
        [DataMember]
        public string CommunicationStateName { get; set; }


        [JsonProperty("CommunicationDistrictId")]
        [DataMember]
        public Int32 CommunicationDistrictId { get; set; }


        [JsonProperty("CommunicationDistrictName")]
        [DataMember]
        public string CommunicationDistrictName { get; set; }


        [JsonProperty("CommunicationPinNumber")]
        [DataMember]
        public string CommunicationPinNumber { get; set; }


        [JsonProperty("CommunicationPhoneNumber")]
        [DataMember]
        public string CommunicationPhoneNumber { get; set; }


        [JsonProperty("CommunicationFax")]
        [DataMember]
        public string CommunicationFax { get; set; }



        [JsonProperty("NoofLiveTerminals")]
        [DataMember]
        public Int32 NoofLiveTerminals { get; set; }



        [JsonProperty("TerminalTypeRequested")]
        [DataMember]
        public string TerminalTypeRequested { get; set; }



        [JsonProperty("MerchantStatusId")]
        [DataMember]
        public int MerchantStatusId { get; set; }


        [JsonProperty("MerchantStatusName")]
        [DataMember]
        public string MerchantStatusName { get; set; }


        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonProperty("CreatedTime")]
        [DataMember]
        public DateTime CreatedTime { get; set; }


        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


        [JsonProperty("ModifiedTime")]
        [DataMember]
        public DateTime ModifiedTime { get; set; }

        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonProperty("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [JsonProperty("Approvedon")]
        [DataMember]
        public DateTime Approvedon { get; set; }

        [JsonProperty("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }
    }
}
