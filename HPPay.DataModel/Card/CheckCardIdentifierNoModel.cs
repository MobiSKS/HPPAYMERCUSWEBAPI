using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CheckCardIdentifierNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CheckCardIdentifierNoModelOutput : BaseClassOutput
    {

    }
}
