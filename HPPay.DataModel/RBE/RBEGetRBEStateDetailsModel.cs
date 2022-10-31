using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RBEGetRBEStateDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("RBEID")]
        [DataMember]
        public string RBEID { get; set; }
    }

    public class RBEGetRBEStateDetailsModelOutput : BaseClassOutput
    {
       
        [JsonProperty("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [JsonProperty("Statename")]
        [DataMember]
        public string Statename { get; set; }
    }
}
