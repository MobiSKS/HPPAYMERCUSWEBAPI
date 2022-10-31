using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantSearchMerchantModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonPropertyName("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonPropertyName("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }

        [JsonPropertyName("HighwayNo")]
        [DataMember]
        public string HighwayNo { get; set; }

        [JsonPropertyName("MerchantStatus")]
        [DataMember]
        public string MerchantStatus { get; set; }
    }

    public class MerchantSearchMerchantModelOutput
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


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }


        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }

        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }

        [JsonProperty("HighwayNo")]
        [DataMember]
        public string HighwayNo { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

    }


}
