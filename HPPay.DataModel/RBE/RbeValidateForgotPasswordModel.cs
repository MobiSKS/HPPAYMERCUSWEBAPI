using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RbeValidateForgotPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [Required]
        [JsonPropertyName("NewPassword")]
        [DataMember]
        public string NewPassword { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }
    }

    public class RbeValidateForgotPasswordModelOutput : BaseClassOutput
    {

    }
}
