using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class VerifyMerchantByMerchantIdModelInput : BaseClass
    { 
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    

    public class VerifyMerchantByMerchantIdModelOutput : BaseClassOutput
    {

    }


   
}
