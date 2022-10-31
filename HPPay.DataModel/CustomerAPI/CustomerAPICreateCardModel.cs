using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPICreateCardModelInput: CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
       [StringLength(10, ErrorMessage = "vehicleType Max Length is 10")]
        [JsonPropertyName("vehicleType")]
        [DataMember]
        public string vehicleType { get; set; }


        [Required]
        [JsonPropertyName("vehicleNumber")]
        [RegularExpression(@"^[a-zA-Z0-9''']+$", ErrorMessage = "Invalid Vehicle Number")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Invalid length of Vehicle Number, Should be between 6 to 12.")]
        [DataMember]
        public string vehicleNumber { get; set; }


        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        [RegularExpression(@"^[0-9'''{4}]+$", ErrorMessage = "Invalid Registraion Year")]
        [JsonPropertyName("registrationYear")]
        [DataMember]
        public string registrationYear { get; set; }
  
        [Required]
        [JsonPropertyName("manufacturer")]
        [RegularExpression(@"^[A-Za-z0-9]$",ErrorMessage = "No Special Characters allowed for Manufacturer")]
        [DataMember]
        public string manufacturer { get; set; }

        [RegularExpression(@"^[6789]\d{9}$",ErrorMessage = "Invalid Mobile Number")]
        [JsonPropertyName("mobileNo")]
        [DataMember]
        public string mobileNo { get; set; }


        [Required]
        [JsonPropertyName("cardPreferenceType")]
        [DataMember]
        public string cardPreferenceType { get; set; }

        [Required]
        [JsonPropertyName("RCDoc")]
        [DataMember]
        public IFormFile RCDoc { get; set; }

    }

    public class CustomerAPICreateCardModelOutput : CustomerAPIBaseClassOutput
    {
    
        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("vehicleType")]
        [DataMember]
        public string vehicleType { get; set; }

        [JsonProperty("vehicleNumber")]
        [DataMember]
        public string vehicleNumber { get; set; }

        [JsonProperty("registrationYear")]
        [DataMember]
        public int registrationYear { get; set; }

        [JsonProperty("cardPreferenceType")]
        [DataMember]
        public string cardPreferenceType { get; set; }

        [JsonProperty("mobileNo")]
        [DataMember]
        public string mobileNo { get; set; }

        [JsonProperty("manufacturer")]
        [DataMember]
        public string manufacturer { get; set; }
    }
}
