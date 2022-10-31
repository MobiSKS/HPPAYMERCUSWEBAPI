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
    public class CustomerDashboardUpdateVerifyYourDetailsModelInput : BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonPropertyName("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }
    }
    public class CustomerDashboardUpdateVerifyYourDetailsModelOutput : BaseClassOutput
    {

        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

    }
}
