using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AdvanceSearch
{
    public class GetAdvanceSearchMerchantSearchModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("IsMerchantIdExist")]
        [DataMember]
        public bool IsMerchantIdExist { get; set; }


        [JsonPropertyName("MerchantType")]
        [DataMember]
        public int? MerchantType { get; set; }


        [JsonPropertyName("IsMerchantTypeExist")]
        [DataMember]
        public bool IsMerchantTypeExist { get; set; }


        [JsonPropertyName("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }


        [JsonPropertyName("IsMerchantNameExist")]
        [DataMember]
        public bool IsMerchantNameExist { get; set; }


        [JsonPropertyName("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonPropertyName("IsRetailOutletNameExist")]
        [DataMember]
        public bool IsRetailOutletNameExist { get; set; }


        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonPropertyName("IsErpCodeExist")]
        [DataMember]
        public bool IsErpCodeExist { get; set; }


        [JsonPropertyName("Status")]
        [DataMember]
        public int? Status { get; set; }


        [JsonPropertyName("IsStatusExist")]
        [DataMember]
        public bool IsStatusExist { get; set; }


        //[JsonPropertyName("Owner")]
        //[DataMember]
        //public string Owner { get; set; }

        [JsonPropertyName("IsOwnerExist")]
        [DataMember]
        public bool IsOwnerExist { get; set; }


        [JsonPropertyName("RegionalOfficeID")]
        [DataMember]
        public int? RegionalOfficeID { get; set; }

        [JsonPropertyName("IsRegionalOfficeExist")]
        [DataMember]
        public bool IsRegionalOfficeExist { get; set; }


        [JsonPropertyName("RetailOffCity")]
        [DataMember]
        public string RetailOffCity { get; set; }


        [JsonPropertyName("IsRetailOffCityExist")]
        [DataMember]
        public bool IsRetailOffCityExist { get; set; }


        [JsonPropertyName("RetailOffDistrict")]
        [DataMember]
        public int? RetailOffDistrict { get; set; }


        [JsonPropertyName("IsRetailOffDistrictExist")]
        [DataMember]
        public bool IsRetailOffDistrictExist { get; set; }


        [JsonPropertyName("RetailOffState")]
        [DataMember]
        public int? RetailOffState { get; set; }

        [JsonPropertyName("IsRetailOffStateExist")]
        [DataMember]
        public bool IsRetailOffStateExist { get; set; }


        [JsonPropertyName("RetailOffPinCode")]
        [DataMember]
        public int? RetailOffPinCode { get; set; }

        [JsonPropertyName("IsRetailOffPinCodeExist")]
        [DataMember]
        public bool IsRetailOffPinCodeExist { get; set; }
    }
    public class GetAdvanceSearchMerchantSearchModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }

        //[JsonProperty("Status")]
        //[DataMember]
        //public string Status { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }

        [JsonProperty("RetailOffDistrict")]
        [DataMember]
        public string RetailOffDistrict { get; set; }

        [JsonProperty("RetailOffState")]
        [DataMember]
        public string RetailOffState { get; set; }

        [JsonProperty("RetailOutletPinNumber")]
        [DataMember]
        public string RetailOutletPinNumber { get; set; }

        [JsonProperty("RetailOutletPhoneNumber")]
        [DataMember]
        public string RetailOutletPhoneNumber { get; set; }
       
    }
}
