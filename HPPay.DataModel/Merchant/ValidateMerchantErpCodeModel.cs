using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class ValidateMerchantErpCodeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }
    }

    public class ValidateMerchantErpCodeModelOutput : BaseClassOutput
    {

    }
}
