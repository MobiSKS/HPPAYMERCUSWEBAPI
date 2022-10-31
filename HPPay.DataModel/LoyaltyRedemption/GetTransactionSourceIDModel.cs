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
    public class GetTransactionSourceIDModelInput : BaseClass
    {
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }
    }
    public class GetTransactionSourceIDModelOutput : BaseClassOutput
    {

        [JsonProperty("StatusId")]
        [DataMember]
        public string StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }



    }
}

