using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{


    public class CustomerGetMerchantForCardMappingModelInput : BaseClass
    {

        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

       
        [JsonPropertyName("StateID")]
        [DataMember]
        public string StateID { get; set; }


        [JsonPropertyName("DistrictID")]
        [DataMember]
        public string DistrictID { get; set; }

        [JsonPropertyName("City")]
        [DataMember]
        public string City { get; set; }


        [JsonPropertyName("HighwayName")]
        [DataMember]
        public string HighwayName { get; set; }

        [JsonPropertyName("HighwayNo1")]
        [DataMember]
        public string HighwayNo1 { get; set; }

        [JsonPropertyName("HighwayNo2")]
        [DataMember]
        public string HighwayNo2 { get; set; }


    }

    public class CustomerGetMerchantForCardMappingModelOutput
    {


        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }


        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }


         

    }
}
