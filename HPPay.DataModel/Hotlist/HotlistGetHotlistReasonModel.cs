using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Hotlist
{
    public class HotlistGetHotlistReasonModelInput : BaseClass
    {

    }
    public class HotlistGetHotlistReasonModelOutput
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


    }

}
