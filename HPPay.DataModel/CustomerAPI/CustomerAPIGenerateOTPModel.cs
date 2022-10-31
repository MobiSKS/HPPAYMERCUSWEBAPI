using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGenerateOTPModelInput : CustomerAPIBaseClassInput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }
    }

    public class CustomerAPIGenerateOTPModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [JsonProperty("OTPGenerationDateTime")]
        [DataMember]
        public string OTPGenerationDateTime { get; set; }
    }
}
