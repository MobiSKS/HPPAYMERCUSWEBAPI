using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

    }

}
