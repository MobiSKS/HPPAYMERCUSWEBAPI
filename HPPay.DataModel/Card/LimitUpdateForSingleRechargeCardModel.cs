using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class LimitUpdateForSingleRechargeCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjCCMSLimits")]
        [DataMember]
        public List<SinglerecgargeCCMSLimitsModelInput> ObjCCMSLimits { get; set; }
    }

    public class SinglerecgargeCCMSLimitsModelInput
    {

        //[Required]
        //[JsonPropertyName("CustomerID")]
        //[DataMember]
        //public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }
        
        [JsonPropertyName("Limittype")]
        [DataMember]
        public int Limittype { get; set; }

        //[Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
              

    }

    public class LimitUpdateForSingleRechargeCardModelOutput : BaseClassOutput
    {

    }
}
