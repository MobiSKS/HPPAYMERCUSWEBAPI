using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantSearchMerchantForCardCreationModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    public class MerchantSearchMerchantForCardCreationModelOutput : BaseClassOutput
    {
        

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

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

        
    }


   
}
