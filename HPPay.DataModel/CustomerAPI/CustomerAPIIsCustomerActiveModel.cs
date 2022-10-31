using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIIsCustomerActiveModelInput:CustomerAPIBaseClassInput
    {
          
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class CustomerAPIIsCustomerActiveModelOutput:CustomerAPIBaseClassOutput
    {
        [JsonProperty("IsActive")]
        [DataMember]
        public string IsActive { get; set; }
    }
    }

