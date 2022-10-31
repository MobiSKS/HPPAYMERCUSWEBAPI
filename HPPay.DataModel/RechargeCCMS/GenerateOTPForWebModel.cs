using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{     

    public class WebGenerateOTPModelInput : BaseClass
    {

        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("OTPtype")]
        [DataMember]
        public int OTPtype { get; set; }
        

        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [JsonPropertyName("TransTypeId")]
        [DataMember]
        public int TransTypeId { get; set; }


        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }



    }
    public class WebGenerateOTPModelOutput : BaseClassOutput
    {
        
        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
         
        
    }
}
