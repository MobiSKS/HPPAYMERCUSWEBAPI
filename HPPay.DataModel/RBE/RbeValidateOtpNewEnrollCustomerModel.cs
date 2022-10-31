using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RbeValidateOtpNewEnrollCustomerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [Required]
        [JsonPropertyName("OTPType")]
        [DataMember]
        public Int32 OTPType { get; set; }

        [JsonPropertyName("CommunicationEmailId")]
        [DataMember]
        public string CommunicationEmailId { get; set; }

        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }
    }
    public class RbeValidateOtpNewEnrollCustomerModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }
}
