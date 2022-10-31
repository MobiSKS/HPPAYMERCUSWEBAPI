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
    public class GetNotificationContentModelInput : BaseClass
    {
        [JsonPropertyName("UserType")]
        [DataMember]
        public string UserType { get; set; }

    }
    public class GetNotificationContentModelOutput : BaseClassOutput
    {

        [JsonProperty("Content")]
        [DataMember]
        public string Content { get; set; }

    }
}
