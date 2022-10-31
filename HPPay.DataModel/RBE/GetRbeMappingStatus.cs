using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{

    public class GetRbeMappingStatusModelInput : BaseClass
    {

    }
    public class GetRbeMappingStatusModelOutput
    {
        [JsonPropertyName("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonPropertyName("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

      

    }
}
