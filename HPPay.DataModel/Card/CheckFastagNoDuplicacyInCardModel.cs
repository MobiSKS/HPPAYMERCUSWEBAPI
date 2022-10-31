using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CheckFastagNoDuplicacyInCardModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("FastagNo")]
        [DataMember]
        public string FastagNo { get; set; }
    }

    public class CheckFastagNoDuplicacyInCardModelOutput:BaseClassOutput
    {
    }
}
