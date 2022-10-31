using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetRequestReactivationMerchantModelInput : BaseClass
    {

        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("MerchantZO")]
        [DataMember]
        public int MerchantZO { get; set; }

        [JsonPropertyName("MerchantRO")]
        [DataMember]
        public int MerchantRO { get; set; }

        [JsonPropertyName("MerchantStatus")]
        [DataMember]
        public int MerchantStatus { get; set; }

        [JsonPropertyName("HotlistDate")]
        [DataMember]
        public string HotlistDate { get; set; }
    }

    public class MerchantGetRequestReactivationMerchantModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("HotListReasonId")]
        [DataMember]
        public int HotListReasonId { get; set; }


        [JsonProperty("HotlistedDate")]
        [DataMember]
        public string HotlistedDate { get; set; }

        [JsonProperty("Flag")]
        [DataMember]
        public string Flag { get; set; }


        [JsonProperty("MerchantStatus")]
        [DataMember]
        public string MerchantStatus { get; set; }


        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }
}
