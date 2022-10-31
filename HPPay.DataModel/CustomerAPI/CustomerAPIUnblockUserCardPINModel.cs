using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIUnblockUserCardPINModelInput: CustomerAPIBaseClassInput
    {
        
           [Required]
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

    }
    public class CustomerAPIUnblockUserCardPINModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }
    }
}
