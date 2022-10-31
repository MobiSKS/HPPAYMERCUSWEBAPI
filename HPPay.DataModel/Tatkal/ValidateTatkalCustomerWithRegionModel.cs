using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Tatkal
{
    public class ValidateTatkalCustomerWithRegionModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("RegionalId")]
        [DataMember]
        public string RegionalId { get; set; }
    }

    public class ValidateTatkalCustomerWithRegionModelOutput : BaseClassOutput
    {

    }
}
