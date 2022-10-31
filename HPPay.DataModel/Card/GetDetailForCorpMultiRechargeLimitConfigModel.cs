using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class GetDetailForCorpMultiRechargeLimitConfigModelInput
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetDetailForCorpMultiRechargeLimitConfigModelOutput:BaseClassOutput
    {       
        [JsonProperty("LimitId")]
        [DataMember]
        public int LimitId { get; set; }

        [JsonProperty("TypeOfLimit")]
        [DataMember]
        public string TypeOfLimit { get; set; }

        [JsonProperty("CheckUncheckId")]
        [DataMember]
        public int CheckUncheckId { get; set; }
    }

    public class CorpMultiRechargeLimitConfigModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjLimitConfig")]
        [DataMember]
        public List<MultiRechargeLimitConfigModelInpu> ObjLimitConfig { get; set; }
    }

    public class MultiRechargeLimitConfigModelInpu
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("Limittype")]
        [DataMember]
        public int Limittype { get; set; }

        [Required]
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }


    }

    public class CorpMultiRechargeLimitConfigModelOutput : BaseClassOutput
    {

    }
}
