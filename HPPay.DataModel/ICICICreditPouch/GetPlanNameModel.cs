using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class GetPlanNameModelICICIInput : BaseClass
    { 
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; } 
    }
    public class GetPlanNameModelICICIOutPut
    {
        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("PlanId")]
        [DataMember]
        public int PlanId { get; set; }

    }
}
