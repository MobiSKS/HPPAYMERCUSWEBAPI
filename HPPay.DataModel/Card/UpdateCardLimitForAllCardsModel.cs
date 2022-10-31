using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class UpdateCardLimitForAllCardsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Cashpurse")]
        [DataMember]
        public decimal Cashpurse { get; set; }

        [Required]
        [JsonPropertyName("Saletxn")]
        [DataMember]
        public int Saletxn { get; set; }

        [Required]
        [JsonPropertyName("Dailysale")]
        [DataMember]
        public int Dailysale { get; set; }


        [Required]
        [JsonPropertyName("Monthlysale")]
        [DataMember]
        public int Monthlysale { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class UpdateCardLimitForAllCardsModelOutput : BaseClassOutput
    {

    }
}
