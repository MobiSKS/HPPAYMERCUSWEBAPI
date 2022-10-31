using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerRelationship
{
    public class CustomerRelationshipSegmentServedModelInput:BaseClass
    {
    }

    public class CustomerRelationshipSegmentServedModelOutput : BaseClassOutput
    {
        [JsonProperty("SegmentServedId")]
        [DataMember]
        public int SegmentServedId { get; set; }

        [JsonProperty("SegmentServedName")]
        [DataMember]
        public string SegmentServedName { get; set; }
    }
}
