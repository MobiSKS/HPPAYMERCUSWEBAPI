using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantSearchForTerminalInstallationRequestCloseModelInput : BaseClass
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

    public class MerchantSearchForTerminalInstallationRequestCloseModelOutput 
    {

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

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


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("TerminalTypeRequested")]
        [DataMember]
        public string TerminalTypeRequested { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }

    }
}
