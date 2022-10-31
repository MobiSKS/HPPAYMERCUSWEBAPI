using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HPPay.DataModel.TMFL
{
    public  class CreateCardModelInput 
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string vehicleNumber { get; set; }

        [Required]
        [JsonPropertyName("RegistrationYear")]
        [DataMember]
        public string registrationYear { get; set; }

        [Required]
        [JsonPropertyName("CardPreferenceType")]
        [DataMember]
        public string cardPreferenceType { get; set; }

        [Required]
        [JsonPropertyName("Manufacturer")]
        [DataMember]
        public string manufacturer { get; set; }

         
        [JsonPropertyName("mobileNo")]
        [DataMember]
        public string mobileNo { get; set; }

        public string CreatedBy { get; set; }

        [JsonPropertyName("RCDoc")]
        [DataMember]
        public IFormFile RCDoc { get; set; }

    }

    public class CreateCardModelOutPut : BaseClassOutput
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }



        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }


        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("CardPreferenceType")]
        [DataMember]
        public string CardPreferenceType { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
       
    }
}
