using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetAllUnAllocatedCardsModelInput :BaseClass
    {
        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }
    }

    public class MerchantGetAllUnAllocatedCardsModelOutput
    {
        [JsonProperty("ObjNoOfUnAllocatedCard")]
        public List<NoOfUnAllocatedCard> ObjNoOfUnAllocatedCard { get; set; }

        [JsonProperty("ObjUnAllocatedCard")]
        public List<UnAllocatedCard> ObjUnAllocatedCard { get; set; }
    }


    public class NoOfUnAllocatedCard
    {

        [JsonProperty("NoOfUnAllocatedCards")]
        [DataMember]
        public Int32 NoOfUnAllocatedCards { get; set; }

         
    }
    public class UnAllocatedCard
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

         
    }
}
