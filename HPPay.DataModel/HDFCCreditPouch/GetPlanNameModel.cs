using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class GetPlanNameModelHDFCInput : BaseClass
    {
         
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; } 
    }
    public class GetPlanNameModelHDFCOutPut
    {
        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("PlanId")]
        [DataMember]
        public int PlanId { get; set; } 

    }
}
