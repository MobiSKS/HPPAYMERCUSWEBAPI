using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetAvailityALOTCCardCardInput : BaseClass
    {

        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }
    }

    public class GetAvailityALOTCCardCardOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
}
