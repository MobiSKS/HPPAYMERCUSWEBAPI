using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RBEGetModelInput : BaseClass
    {
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }

    public class RBEGetModelOutput : BaseClassOutput
    {
        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }
    }
}
