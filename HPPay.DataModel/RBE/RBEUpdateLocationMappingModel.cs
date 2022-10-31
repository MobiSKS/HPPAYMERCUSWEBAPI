using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RBEUpdateLocationMappingModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }
    public class RBEUpdateLocationMappingModelOutput : BaseClassOutput
    {

    }

}
