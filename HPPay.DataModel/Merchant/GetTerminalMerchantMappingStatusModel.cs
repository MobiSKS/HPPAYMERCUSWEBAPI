using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetTerminalMerchantMappingStatusModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("Todate")]
        [DataMember]
        public string Todate { get; set; }
    }


    public class GetTerminalMerchantMappingStatusModelOutput : BaseClassOutput
    {
        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

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

        [JsonProperty("Requested Date")]
        [DataMember]
        public DateTime RequestedDate { get; set; }

        [JsonProperty("Requested By")]
        [DataMember]
        public string RequestedBy { get; set; }


        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}
