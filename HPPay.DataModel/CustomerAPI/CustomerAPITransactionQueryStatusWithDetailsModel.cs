using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPITransactionQueryStatusWithDetailsModelInput: CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

     
    }

    public class CustomerAPITransactionQueryStatusWithDetailsModelOutput:CustomerAPIBaseClassOutput
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
