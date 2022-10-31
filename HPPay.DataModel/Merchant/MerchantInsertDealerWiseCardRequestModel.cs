using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    

    public class MerchantInsertDealerWiseCardRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("NoofCards")]
        [DataMember]
        public Int32 NoofCards { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class MerchantInsertDealerWiseCardRequestModelOutput : BaseClassOutput
    {

    }
}
