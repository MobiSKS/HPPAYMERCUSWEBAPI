using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    public class GetJCBCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetJCBCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }
    }

    public class UpdateJCBCommunicationEmailResetPasswordModelInput : BaseClass
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

    public class UpdateJCBCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

    }


    public class UpdateJCBDealerCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


    }

    public class UpdateJCBDealerCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

    }
}
