using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPICheckCustomerActivityModelInput:CustomerAPIBaseClassInput

    {
        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }
    }
 

    public class CustomerAPICheckCustomerActivityModelOutput : CustomerAPIBaseClassOutput
    {
        //[JsonProperty("VehicleNumber")]
        //[DataMember]
        //public string VehicleNumber { get; set; }
    }
}
