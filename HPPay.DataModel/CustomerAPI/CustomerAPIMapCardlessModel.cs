using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIMapCardlessModelInput : CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }


       
        [JsonPropertyName("mobile")]
        [DataMember]
        public string mobile { get; set; }


       
        [JsonPropertyName("manipulationType")]
        [DataMember]
        public string manipulationType { get; set; }

        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

      
        [JsonPropertyName("PONumber")]
        [DataMember]
        public string PONumber { get; set; }

       
        [JsonPropertyName("FastlaneTagNumber")]
        [DataMember]
        public string FastlaneTagNumber { get; set; }

       
        [JsonPropertyName("Validity")]
        [DataMember]
        public string Validity { get; set; }
    }

    public class CustomerAPIMapCardlessModelOutput : CustomerAPIBaseClassOutput
    {

    }
}
