using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class CheckICICICreditPouchEligibilityModelInput : BaseClass
    {
            [Required]
            [JsonPropertyName("CustomerId")]
            [DataMember]
            public string CustomerId { get; set; }

    }
    public class CheckICICICreditPouchEligibilityModelOutPut : BaseClassOutput
    {
        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("PlanTypeId")]
        [DataMember]
        public int PlanTypeId { get; set; }
    }

}

