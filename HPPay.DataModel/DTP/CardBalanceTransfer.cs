using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DTP
{

    public class CardBalanceTransferModelInput
    {
        [Required]
        [JsonPropertyName("CardStatus")]
        [DataMember]
        public int CardStatus { get; set; }

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string Cardno { get; set; }
        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class CardBalanceTransferModelOutput : BaseClassOutput
    {

    }

}
