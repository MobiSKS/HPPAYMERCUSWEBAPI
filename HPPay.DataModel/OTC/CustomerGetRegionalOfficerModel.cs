using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.OTC
{
    public class CustomerGetRegionalOfficerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class CustomerGetRegionalOfficerModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }

}
