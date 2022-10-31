using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class GetCustomerSubTypeModelInput : BaseClass
    {
        [JsonPropertyName("CustomerTypeId")]
        [DataMember]
        public int CustomerTypeId { get; set; }
    }
    public class GetCustomerSubTypeModelOutput
    {
        [JsonProperty("CustomerSubtypeId")]
        [DataMember]
        public int CustomerSubtypeId { get; set; }

        [JsonProperty("CustomerSubtypeName")]
        [DataMember]
        public string CustomerSubtypeName { get; set; }
    }
}
