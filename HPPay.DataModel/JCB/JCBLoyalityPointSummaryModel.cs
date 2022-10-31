using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.JCB
{
    internal class JCBLoyalityPointSummaryModel
    {
    }
    public class JCBLoyalityPointSummaryModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public DateTime FromDate { get; set; }

        [Required]
        [JsonPropertyName("Todate")]
        [DataMember]
        public DateTime Todate { get; set; }

    }
    public class JCBLoyalityPointSummaryModelOutput : BaseClassOutput
    {
        [JsonProperty("TotalSale")]
        [DataMember]
        public string TotalSale { get; set; }

        [JsonProperty("ApplicableSlab")]
        [DataMember]
        public string ApplicableSlab { get; set; }

        [JsonProperty("PointAwarded")]
        [DataMember]
        public string PointAwarded { get; set; }

        [JsonProperty("RewardType")]
        [DataMember]
        public string RewardType { get; set; }

        [JsonProperty("StartDate")]
        [DataMember]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        [DataMember]
        public string EndDate { get; set; }

        [JsonProperty("TotalVolume")]
        [DataMember]
        public string TotalVolume { get; set; }


    }
}
