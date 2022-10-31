using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class GetUpdateLoyaltyRedemptionModelInput : BaseClass
    {
       [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

       [JsonPropertyName("Points")]
        [DataMember]
        public string Points { get; set; }
    }
    public class GetUpdateLoyaltyRedemptionModelOutput : BaseClassOutput
    {
        [JsonProperty("Balancedloyaltypoint")]
        [DataMember]
        public string Balancedloyaltypoint { get; set; }

    }
}
