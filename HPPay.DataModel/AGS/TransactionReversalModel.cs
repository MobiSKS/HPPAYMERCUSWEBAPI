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
    public class TransactionReversalModelInput:AGSAPIBaseClassInput
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
        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public string TransactionAmount { get; set; }



       
      
      
        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }

        [Required]
        [JsonPropertyName("BatchId")]
        [DataMember]
        public string BatchId { get; set; }


        [Required]
        [JsonPropertyName("DeviceID")]
        [DataMember]
        public string DeviceID { get; set; }


        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [Required]
        [JsonPropertyName("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }


        [Required]
        [JsonPropertyName("HashKey")]
        [DataMember]
        public string HashKey { get; set; }


    }

    public class TransactionReversalModelOutput : AGSBaseClassOutput
    {
       
    }
}
    