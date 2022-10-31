using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class GetRMRechargeModeModelInput:BaseClass
    {

    }
    public class GetRMRechargeModeModelOutput
    {
        [JsonProperty("RechargeModeId")]
        [DataMember]
        public int RechargeModeId { get; set; }

        [JsonProperty("RechargeModeName")]
        [DataMember]
        public string RechargeModeName { get; set; }
    }
}
