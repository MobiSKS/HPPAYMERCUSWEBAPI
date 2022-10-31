using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class UpdateRedemptionRequestRuleModelInput : BaseClass
    {
        [JsonPropertyName("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }

        [JsonPropertyName("MinimumAmount")]
        [DataMember]
        public string MinimumAmount { get; set; }

        [JsonPropertyName("MaximumAmount")]
        [DataMember]
        public string MaximumAmount { get; set; }

        [JsonPropertyName("TransactionSourceId")]
        [DataMember]
        public int TransactionSourceId { get; set; }

        [JsonPropertyName("AuthorizationLevelId")]
        [DataMember]
        public int AuthorizationLevelId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("RuleId")]
        [DataMember]
        public string RuleId { get; set; }

    }
    public class UpdateRedemptionRequestRuleModelOutput : BaseClassOutput
    {


    }
}
