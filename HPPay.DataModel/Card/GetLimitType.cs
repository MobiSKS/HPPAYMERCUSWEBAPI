using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class GetLimitTypeModelInput : BaseClass
    {

    }
    public class GetLimitTypeModelOutput : BaseClassOutput
    {
        [JsonProperty("Id")]
        [DataMember]
        public string Id { get; set; }

        [JsonProperty("LimitType")]
        [DataMember]
        public string LimitType { get; set; }

    }

}
