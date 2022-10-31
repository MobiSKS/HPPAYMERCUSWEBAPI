using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class UpdateCardStatusModelInput : BaseClass
    {


        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [Required]
        [JsonPropertyName("Statusflag")]
        [DataMember]
        public int Statusflag { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class UpdateCardStatusModelOutput : BaseClassOutput
    {

    }
}
