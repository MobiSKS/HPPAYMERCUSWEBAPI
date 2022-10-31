using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Card
{


    public class GetLimitMasterModelInput : BaseClass
    {
        
    }
    public class GetLimitMasterModelOutput
    {
        [JsonProperty("LimitId")]
        [DataMember]
        public int LimitId { get; set; }

        [JsonProperty("Description")]
        [DataMember]
        public string Description { get; set; }

    }
}
