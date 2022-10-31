using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetCardBalanceModelInput: CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [JsonPropertyName("cardNumbers")]
        [DataMember]
        public string cardNumbers { get; set; }
    }

    public class CustomerAPIGetCardBalanceModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("cardNo")]
        [DataMember]
        public string cardNo { get; set; }

        [JsonProperty("vehicleNumber")]
        [DataMember]
        public string vehicleNumber { get; set; }

        [JsonProperty("cardBalance")]
        [DataMember]
        public decimal cardBalance { get; set; }
    }
}
