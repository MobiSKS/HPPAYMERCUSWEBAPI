using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    
    public class MerchantViewTerminalDeInstallationRequestStatusModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }


        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class MerchantViewTerminalDeInstallationRequestStatusModelOutput
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


        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }


        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }


        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }

    }
}
