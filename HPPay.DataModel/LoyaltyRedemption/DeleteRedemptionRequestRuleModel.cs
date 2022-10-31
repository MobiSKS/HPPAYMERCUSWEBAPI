using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class DeleteRedemptionRequestRuleModelInput : BaseClass
    {
        [JsonPropertyName("RuleId")]
        [DataMember]
        public int RuleId { get; set; }
    }
    public class DeleteRedemptionRequestRuleModelOutput : BaseClassOutput
    {


    }
}
