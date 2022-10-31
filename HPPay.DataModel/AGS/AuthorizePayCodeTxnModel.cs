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
    public class AuthorizePayCodeTxnModelInput:AGSAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }


        [Required]
        [JsonPropertyName("Paycode")]
        [DataMember]
        public string Paycode { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

      
        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }

        
        [Required]
        [JsonPropertyName("DeviceID")]
        [DataMember]
        public string DeviceID { get; set; }


      

    }
    public class AuthorizePayCodeTxnModelOutput : AGSBaseClassOutput
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


        [JsonProperty("BatchId")]
        [DataMember]
        public string BatchId { get; set; }

    }


}
