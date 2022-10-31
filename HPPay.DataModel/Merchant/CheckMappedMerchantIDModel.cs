using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class CheckMappedMerchantIDModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MappedMerchantID")]
        [DataMember]
        public string MappedMerchantID { get; set; }
    }

    public class CheckMappedMerchantIDModelOutput : BaseClassOutput
    {

    }
}
