using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.MerchantDashboard
{
    public class MerchantDashboardKeyEventsAndFiguresModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    public class MerchantDashboardKeyEventsAndFiguresModelOutput : BaseClassOutput
    {
        [JsonProperty("LastLogin")]
        [DataMember]
        public string LastLogin { get; set; }

        [JsonProperty("LastTransaction")]
        [DataMember]
        public string LastTransaction { get; set; }

        [JsonProperty("LastCashReload")]
        [DataMember]
        public string LastCashReload { get; set; }

        [JsonProperty("LastCashSale")]
        [DataMember]
        public string LastCashSale { get; set; }

        [JsonProperty("LastCCMSRecharge")]
        [DataMember]
        public string LastCCMSRecharge { get; set; }

        [JsonProperty("LastBatchSettled")]
        [DataMember]
        public string LastBatchSettled { get; set; }

        [JsonProperty("UnsettledBatchNumber")]
        [DataMember]
        public string UnsettledBatchNumber { get; set; }

        [JsonProperty("UnsettledTxnCount")]
        [DataMember]
        public string UnsettledTxnCount { get; set; }

        [JsonProperty("LastPasswordChange")]
        [DataMember]
        public string LastPasswordChange { get; set; }

        [JsonProperty("LastContactDetailsUpdate")]
        [DataMember]
        public string LastContactDetailsUpdate { get; set; }


    }
}
