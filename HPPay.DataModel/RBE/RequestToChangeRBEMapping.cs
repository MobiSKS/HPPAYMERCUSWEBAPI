using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RequestToChangeRBEMappingModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("PreRBEUserName")]
        [DataMember]
        public string PreRBEUserName { get; set; }

        //[Required]
        [JsonPropertyName("NewRBEUserName")]
        [DataMember]
        public string NewRBEUserName { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class RequestToChangeRBEMappingModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }
}
