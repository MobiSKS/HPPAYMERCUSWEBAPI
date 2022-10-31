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
    public class MODashboardUserInformationModelInput : BaseClass
    {

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }
    public class MODashboardUserInformationModelOutput : BaseClassOutput
    {

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("LastLogin")]
        [DataMember]
        public string LastLogin { get; set; }

    }
}
