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
    public class AuthorizationModelInput:AGSAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }


        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [Required]
        [JsonPropertyName("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }


        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }



        [Required]
        [JsonPropertyName("AutomationPIN")]
        [DataMember]
        public string AutomationPIN { get; set; }


        [Required]
        [JsonPropertyName("DeviceID")]
        [DataMember]
        public string DeviceID { get; set; }


        [Required]
        [JsonPropertyName("HashKey")]
        [DataMember]
        public string HashKey { get; set; }



    }


    public class AuthorizationModelOutput : AGSBaseClassOutput
    {
        [JsonProperty("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public string TransactionAmount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("Product")]
        [DataMember]
        public string Product { get; set; }


    }
}
