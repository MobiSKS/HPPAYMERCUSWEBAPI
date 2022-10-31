using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CheckAddOnFormNumberModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
    }
    public class CheckAddOnFormNumberModelOutput : BaseClassOutput
    {

    }
}
