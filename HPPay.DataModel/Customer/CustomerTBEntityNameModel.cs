using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Customer
{

    public class GetCustomerTBEntityNameModelInput : BaseClass
    {
        
    }
    public class GetCustomerTBEntityNameModelOutput
    {
        [JsonProperty("TBEntityId")]
        [DataMember]
        public int TBEntityId { get; set; }

        [JsonProperty("TBEntityName")]
        [DataMember]
        public string TBEntityName { get; set; }
    }
}
