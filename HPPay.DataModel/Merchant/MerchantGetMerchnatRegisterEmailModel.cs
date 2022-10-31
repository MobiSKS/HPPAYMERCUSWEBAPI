using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetMerchnatRegisterEmailModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    

    public class MerchantGetMerchnatRegisterEmailModelOutput : BaseClassOutput
    {
        [JsonProperty("RegisteredEmail")]
        [DataMember]
        public string RegisteredEmail { get; set; }

    }
}
