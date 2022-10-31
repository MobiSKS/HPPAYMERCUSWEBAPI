using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.RBE
{
   
    public class ValidateOtpChangeRbeMobileModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ExistingMobileNo")]
        [DataMember]
        public string ExistingMobileNo { get; set; }

        [Required]
        [JsonPropertyName("NewMobileNo")]
        [DataMember]
        public string NewMobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }

    public class ValidateOtpChangeRbeMobileModelOutput : BaseClassOutput
    {

    }
}
