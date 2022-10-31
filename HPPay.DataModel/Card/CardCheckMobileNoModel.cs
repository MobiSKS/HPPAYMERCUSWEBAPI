using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CardCheckMobileNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }
    }
    public class CardCheckMobileNoModelOutput : BaseClassOutput
    {

    }
}
