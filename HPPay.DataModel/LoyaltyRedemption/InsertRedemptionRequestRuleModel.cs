using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class InsertRedemptionRequestRuleModelInput : BaseClass
    {
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

        [JsonPropertyName("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }
    public class InsertRedemptionRequestRuleModelOutput : BaseClassOutput
    {


    }
}
