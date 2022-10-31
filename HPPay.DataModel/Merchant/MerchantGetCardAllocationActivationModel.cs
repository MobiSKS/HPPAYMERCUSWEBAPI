using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
     

    public class MerchantGetCardAllocationActivationModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class MerchantGetCardAllocationActivationModelOutput
    {

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }


        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }


        [JsonProperty("AuthorizedBy")]
        [DataMember]
        public string AuthorizedBy { get; set; }


        [JsonProperty("AuthorizedDate")]
        [DataMember]
        public string AuthorizedDate { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

    }
}
