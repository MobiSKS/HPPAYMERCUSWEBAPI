using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Merchant
{
    public class VerifyMerchantByMerchantIdandRegionalIdModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }
    }
    public class VerifyMerchantByMerchantIdandRegionalIdModelOutput : BaseClassOutput
    {

    }
}
