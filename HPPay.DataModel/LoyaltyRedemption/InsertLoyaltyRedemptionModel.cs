using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class InsertLoyaltyRedemptionModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Points")]
        [DataMember]
        public string Points { get; set; }

        //[JsonPropertyName("Amount")]
        //[DataMember]
        //public string Amount { get; set; }
    }
    public class InsertLoyaltyRedemptionModelOutput : BaseClassOutput
    {
     

    }
}
