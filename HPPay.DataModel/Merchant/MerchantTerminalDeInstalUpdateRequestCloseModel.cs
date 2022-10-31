using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantTerminalDeInstalUpdateRequestCloseModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjMerchantTerminalMapInput")]
        [DataMember]
        public List<MerchantTerminalMapInput> ObjMerchantTerminalMapInput { get; set; }
    }

    public class MerchantTerminalMapInput
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }

    }

    public class MerchantTerminalDeInstalUpdateRequestCloseModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }
    }
}
