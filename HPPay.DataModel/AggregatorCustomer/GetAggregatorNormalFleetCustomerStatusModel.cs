
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{

    public class GetAggregatorNormalFleetCustomerStatusModelInput : BaseClass
    {

    }
    public class GetAggregatorNormalFleetCustomerStatusModelOutput
    {
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public string StatusId { get; set; }
    }
}
