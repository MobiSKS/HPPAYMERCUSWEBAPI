using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetCustomerTypeOfFleetModelInput : BaseClass
    {
         
    }
    public class GetCustomerTypeOfFleetModelOutput
    {
        [JsonProperty("TypeOfFleetId")]
        [DataMember]
        public int TypeOfFleetId { get; set; }

        [JsonProperty("TypeOfFleetName")]
        [DataMember]
        public string TypeOfFleetName { get; set; }
    }
}
