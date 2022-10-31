using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    internal class SendOtpResetRBEDevice
    {
    }

    public class SendOtpResetRBEDeviceModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class SendOtpResetRBEDeviceModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }
}
