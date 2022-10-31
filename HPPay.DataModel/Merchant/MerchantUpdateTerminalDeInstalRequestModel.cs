using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantUpdateTerminalDeInstalRequestModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("DeinstallationType")]
        [DataMember]
        public string DeinstallationType { get; set; }

        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjUpdateTerminalDeInstalRequest")]
        [DataMember]
        public List<UpdateTerminalDeInstalRequestModelInput> ObjUpdateTerminalDeInstalRequest { get; set; }
    }

    public class UpdateTerminalDeInstalRequestModelInput
    {
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }

    public class MerchantUpdateTerminalDeInstalRequestModelOutput : BaseClassOutput
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }
}
