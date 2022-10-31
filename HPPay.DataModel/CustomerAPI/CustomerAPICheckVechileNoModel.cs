using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPICheckVechileNoModelInput : CustomerAPIBaseClassInput
    {
        [Required]
        [StringLength(12)]
        [JsonPropertyName("VehicleRegistrationNumber")]
        [DataMember]
        public string VehicleRegistrationNumber { get; set; }
    }

    public class CustomerAPICheckVechileNoModelOutput : CustomerAPIBaseClassOutput
    {

    }
}
