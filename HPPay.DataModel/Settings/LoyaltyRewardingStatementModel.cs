using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Settings
{
    public class LoyaltyRewardingStatementModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public DateTime FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public DateTime ToDate { get; set; }
    }
    public class LoyaltyRewardingStatementModelOutput 
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("TypeOfReward")]
        [DataMember]
        public string TypeOfReward { get; set; }

        [JsonProperty("TypeOfRewarding")]
        [DataMember]
        public string TypeOfRewarding { get; set; }

        [JsonProperty("ActualPeriodofRewarding")]
        [DataMember]
        public string ActualPeriodofRewarding { get; set; }

        [JsonProperty("TotalAmount")]
        [DataMember]
        public string TotalAmount { get; set; }

        [JsonProperty("Slab")]
        [DataMember]
        public string Slab { get; set; }

        [JsonProperty("DriveStarRewarded")]
        [DataMember]
        public string DriveStarRewarded { get; set; }

        [JsonProperty("DateofRewarding")]
        [DataMember]
        public string DateofRewarding { get; set; }

        [JsonProperty("FuelRedemption")]
        [DataMember]
        public string FuelRedemption { get; set; }

        [JsonProperty("DrivestarDailyRewarding")]
        [DataMember]
        public string DrivestarDailyRewarding { get; set; }


    }
}
