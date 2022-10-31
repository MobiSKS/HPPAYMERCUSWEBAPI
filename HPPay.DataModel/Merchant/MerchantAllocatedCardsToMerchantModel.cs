using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantAllocatedCardsToMerchantModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("NoOfCardsAllocated")]
        [DataMember]
        public Int32 NoOfCardsAllocated { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjAllocatedCardsToMerchant")]
        [DataMember]
        public List<AllocatedCardsToMerchantModelInput> ObjAllocatedCardsToMerchant { get; set; }
    }

    public class AllocatedCardsToMerchantModelInput
    {
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    }

    public class MerchantAllocatedCardsToMerchantModelOutput : BaseClassOutput
    {

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    }
}
