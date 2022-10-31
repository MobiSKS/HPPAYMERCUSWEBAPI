using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class GetCustomerTypeModelInput : BaseClass
    {
        [JsonPropertyName("CTFlag")]
        [DataMember]
        public int CTFlag { get; set; }
    }
    public class GetCustomerTypeModelOutput
    {
        [JsonProperty("CustomerTypeId")]
        [DataMember]
        public int CustomerTypeId { get; set; }

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }
    }
}
