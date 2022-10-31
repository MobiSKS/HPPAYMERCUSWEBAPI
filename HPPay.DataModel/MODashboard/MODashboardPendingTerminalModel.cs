using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.MODashboard
{
    public class MODashboardPendingTerminalModelInput : BaseClass
    {

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }
    public class MODashboardPendingTerminalModelOutput : BaseClassOutput
    {

        [JsonProperty("Installation")]
        [DataMember]
        public string Installation { get; set; }

        [JsonProperty("De_Installation")]
        [DataMember]
        public string De_Installation { get; set; }

    }
}
