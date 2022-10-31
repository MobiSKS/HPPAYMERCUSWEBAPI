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
    public class BatchSettlementModelInput:AGSAPIBaseClassInput
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
        [JsonPropertyName("TotalAmount")]
        [DataMember]
        public string TotalAmount { get; set; }


        [Required]
        [JsonPropertyName("TotalCount")]
        [DataMember]
        public string TotalCount { get; set; }

        [Required]
        [JsonPropertyName("BatchId")]
        [DataMember]
        public string BatchId { get; set; }

        [Required]
        [JsonPropertyName("DeviceID")]
        [DataMember]
        public string DeviceID { get; set; }

    }

    public class BatchSettlementModelOutput : AGSBaseClassOutput
    {
     

    }

}
