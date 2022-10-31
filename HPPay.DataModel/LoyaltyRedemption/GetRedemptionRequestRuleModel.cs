using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class GetRedemptionRequestRuleModelInput : BaseClass
    {
     
    }
    public class GetRedemptionRequestRuleModelOutput : BaseClassOutput
    {

        [JsonProperty("MinimumAmount")]
        [DataMember]
        public string MinimumAmount { get; set; }

        [JsonProperty("MaximumAmount")]
        [DataMember]
        public string MaximumAmount { get; set; }

        [JsonProperty("TransactionSourceId")]
        [DataMember]
        public int TransactionSourceId { get; set; }

        [JsonProperty("AuthorizationLevelId")]
        [DataMember]
        public int AuthorizationLevelId { get; set; }

        [JsonProperty("TransactionSource")]
        [DataMember]
        public string TransactionSource { get; set; }

        [JsonProperty("AuthorizationLevel")]
        [DataMember]
        public string AuthorizationLevel { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

        [JsonProperty("RuleId")]
        [DataMember]
        public int RuleId { get; set; }


    }
}
