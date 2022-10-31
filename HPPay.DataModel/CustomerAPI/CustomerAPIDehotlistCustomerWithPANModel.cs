using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIDehotlistCustomerWithPANModelInput: CustomerAPIBaseClassInput
    {
     

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public  string CustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN")]
        [StringLength(10, ErrorMessage = "Invalid PAN/PAN must be length of 10.")]
        [JsonPropertyName("PAN")]
        [DataMember]
        public  string PAN { get; set; }
    }
    public class CustomerAPIDehotlistCustomerWithPANModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("pan")]
        [DataMember]
        public string pan{ get; set; } 

        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }
    }
    }
