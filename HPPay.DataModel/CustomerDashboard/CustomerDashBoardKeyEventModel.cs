using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerDashboard
{
    public class CustomerDashBoardKeyEventModelInput : BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerDashBoardKeyEventModelOutput : BaseClassOutput
    {

        [JsonProperty("LastLogin")]
        [DataMember]
        public string LastLogin { get; set; }

        [JsonProperty("LastTransaction")]
        [DataMember]
        public string LastTransaction { get; set; }

        [JsonProperty("LastRedemption")]
        [DataMember]
        public string LastRedemption { get; set; }

        [JsonProperty("LastPasswordChange")]
        [DataMember]
        public string LastPasswordChange { get; set; }

        [JsonProperty("LastContactDetailsUpdate")]
        [DataMember]
        public string LastContactDetailsUpdate { get; set; }

    }
}
