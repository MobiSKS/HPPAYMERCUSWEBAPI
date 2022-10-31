using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{

    public class InsertALCustomerKYCModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }

        [Required]
        [JsonPropertyName("IDProof")]
        [DataMember]
        public IFormFile IDProof { get; set; }

        [Required]
        [JsonPropertyName("PanCardProof")]
        [DataMember]
        public IFormFile PanCardProof { get; set; }

        [Required]
        [JsonPropertyName("VehicleDetail")]
        [DataMember]
        public IFormFile VehicleDetail { get; set; }

        [Required]
        [JsonPropertyName("SignedCustomerForm")]
        [DataMember]
        public IFormFile SignedCustomerForm { get; set; }

      


    }
    public class InsertALCustomerKYCModelOutput : BaseClassOutput
    {
    }
}
