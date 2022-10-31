using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPITransactionQueryStatusModelInput:CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

      
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("transactionId")]
        [DataMember]
        public string transactionId { get; set; }
    }
    public class CustomerAPITransactionQueryStatusModelOutput:CustomerAPIBaseClassOutput
    {
        [JsonProperty("customerId")]
        [DataMember]
        public string customerId { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [StringLength(20)]
        [JsonProperty("transactionID")]
        [DataMember]
        public string transactionID { get; set; }
    }
}
