using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantViewTerminalMerchantMappingStatusModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }
   
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class MerchantViewTerminalMerchantMappingStatusModelOutput:BaseClassOutput
    {
      
        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }

        [JsonProperty("ServiceCharge")]
        [DataMember]
        public decimal ServiceCharge { get; set; }

        [JsonProperty("RouteId")]
        [DataMember]
        public string RouteId { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

         [JsonProperty("TerminalStatus")]
        [DataMember]
        public string TerminalStatus { get; set; }

         [JsonProperty("Remarks")]
         [DataMember]
         public string Remarks { get; set; }
    }
}
