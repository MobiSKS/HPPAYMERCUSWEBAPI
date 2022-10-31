using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class CardCheckVechileNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }
    }
    public class CardCheckVechileNoModelOutput : BaseClassOutput
    {

    }


    public class CheckVechileNoThroughVahanModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }
    }
    public class CheckVechileNoThroughVahanModelOutput : BaseClassOutput
    {

    }

}
