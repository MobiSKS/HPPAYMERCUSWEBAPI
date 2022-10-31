using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{
    public class GetStatusTypesForTerminalModelInput : BaseClass
    {
    }

    public class GetStatusTypesForTerminalModelOutput
    {
        [JsonProperty("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }


        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("StatusCode")]
        [DataMember]
        public string StatusCode { get; set; }


        [JsonProperty("StatusDescription")]
        [DataMember]
        public string StatusDescription { get; set; }
    }
}
