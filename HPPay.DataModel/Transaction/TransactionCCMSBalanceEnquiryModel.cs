using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{

    public class TransactionCCMSBalanceEnquiryModelInput : BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [Required]
        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [Required]
        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [Required]
        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }

        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class TransactionCCMSBalanceEnquiryModelOutput  : BaseClassOutput
    {
        [JsonProperty("CCMSLimitBal")]
        [DataMember]
        public decimal CCMSLimitBal { get; set; }

        [JsonProperty("LoyaltyBalance")]
        [DataMember]
        public decimal LoyaltyBalance { get; set; }
    }
}
