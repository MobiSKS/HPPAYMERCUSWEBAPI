using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class UpdateCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("AlternateEmailId")]
        [DataMember]
        public string AlternateEmailId { get; set; }
    }

    public class UpdateCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }
        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }

}
