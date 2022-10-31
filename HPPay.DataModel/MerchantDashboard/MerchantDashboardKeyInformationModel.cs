using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.MerchantDashboard
{
    public class MerchantDashboardKeyInformationModelInput : BaseClass
    {
        
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    public class MerchantDashboardKeyInformationModelOutput : BaseClassOutput
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("DateOfInstallation")]
        [DataMember]
        public string DateOfInstallation { get; set; }
    }
}
