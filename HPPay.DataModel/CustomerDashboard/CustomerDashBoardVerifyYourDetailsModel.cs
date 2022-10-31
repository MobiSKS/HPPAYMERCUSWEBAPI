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
    public class CustomerDashBoardVerifyYourDetailsModelInput : BaseClass
    {
        
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerDashBoardVerifyYourDetailsModelOutput : BaseClassOutput
    {

        [JsonProperty("RegisteredEmailAddress")]
        [DataMember]
        public string RegisteredEmailAddress { get; set; }

        [JsonProperty("RegisteredMobileNumber")]
        [DataMember]
        public string RegisteredMobileNumber { get; set; }

    }
}
