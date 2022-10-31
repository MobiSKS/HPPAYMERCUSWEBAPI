using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    
    public class GetDICVCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetDICVCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

    }

    public class UpdateDICVCommunicationEmailResetPasswordModelInput : BaseClass
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

    public class UpdateDICVCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

    }

    public class UpdateDicvDealerEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


    }
}
