using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    internal class ValidateOtpResetRBEDevice
    {
    }

    public class ValidateOtpResetRBEDeviceModelInput : BaseClass
    {
      
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }

    public class ValidateOtpResetRBEDeviceModelOutput : BaseClassOutput
    {

    }
}
