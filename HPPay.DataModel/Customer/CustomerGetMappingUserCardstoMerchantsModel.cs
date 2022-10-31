using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Customer
{
    public class CustomerGetMappingUserCardstoMerchantsModelInput : BaseClass
    {
        
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


    }

    public class CustomerGetMappingUserCardstoMerchantsModelOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }
    }
}
