using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantInsertAddonTerminalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("TerminalTypeRequested")]
        [DataMember]
        public string TerminalTypeRequested { get; set; }

        [Required]
        [JsonPropertyName("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("Justification")]
        [DataMember]
        public string Justification { get; set; }
    }

    public class MerchantInsertAddonTerminalModelOutput : BaseClassOutput
    {

    }
}
