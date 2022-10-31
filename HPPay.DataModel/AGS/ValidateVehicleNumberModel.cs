using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public class ValidateVehicleNumberModelInput //:AGSAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }


        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("DeviceID")]
        [DataMember]
        public string DeviceID { get; set; }

        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

    }

    public class ValidateVehicleNumberModelOutput 
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public int responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

    }

    
}
