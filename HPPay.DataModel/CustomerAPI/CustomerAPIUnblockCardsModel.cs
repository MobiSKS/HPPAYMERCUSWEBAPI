using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIUnblockCardsModelInput : CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

    }
    public class CustomerAPIUnblockCardsModelOutput : CustomerAPIBaseClassOutput
    {

        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber{ get; set; }
    }
}
