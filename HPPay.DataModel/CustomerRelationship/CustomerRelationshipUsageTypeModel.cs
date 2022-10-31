using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerRelationship
{
    public class CustomerRelationshipUsageTypeModelInput : BaseClass
    {

    }

    public class CustomerRelationshipUsageTypeModelOutput : BaseClassOutput
    {
        [JsonProperty("UsageTypeId")]
        [DataMember]
        public int UsageTypeId { get; set; }

        [JsonProperty("UsageTypeName")]
        [DataMember]
        public string UsageTypeName { get; set; }
    }
}
