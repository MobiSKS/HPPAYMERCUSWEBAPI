using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class UpdateCCMSLimitForAllCardsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Limittype")]
        [DataMember]
        public int Limittype { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class UpdateCCMSLimitForAllCardsModelOutput : BaseClassOutput
    {

    }
}
