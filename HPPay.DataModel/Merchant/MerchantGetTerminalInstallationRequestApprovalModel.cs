using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetTerminalInstallationRequestApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("Category")]
        [DataMember]
        public string Category { get; set; }


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

    public class MerchantGetTerminalInstallationRequestApprovalModelOutput
    {


        [JsonProperty("New")]
        [DataMember]
        public string New { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("TerminalType")]
        [DataMember]
        public string TerminalType { get; set; }


        [JsonProperty("MerchantStatus")]
        [DataMember]
        public string MerchantStatus { get; set; }

        [JsonProperty("LastMonthSpend")]
        [DataMember]
        public decimal LastMonthSpend { get; set; }


        [JsonProperty("NoOfTransactionsOfLastMonth")]
        [DataMember]
        public Int32 NoOfTransactionsOfLastMonth { get; set; }

        [JsonProperty("RequestType")]
        [DataMember]
        public string RequestType { get; set; }


        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }


        [JsonProperty("Justification")]
        [DataMember]
        public string Justification { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }


        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

    }
}
