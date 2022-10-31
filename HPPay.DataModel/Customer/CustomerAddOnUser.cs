using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
   
    public class CustomerAddOnUserModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class CustomerAddOnUserModelOutput : BaseClassOutput
    {
        
        [JsonProperty("Username")]
        [DataMember]
        public string Username { get; set; }

        
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

    }
}
