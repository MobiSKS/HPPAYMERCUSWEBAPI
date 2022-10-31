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
    public class MerchantDashboardTodaysTransactionSummaryModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    public class MerchantDashboardTodaysTransactionSummaryModelOutput : BaseClassOutput
    {
        [JsonProperty("CardSale")]
        [DataMember]
        public string CardSale { get; set; }

        [JsonProperty("CCMSSale")]
        [DataMember]
        public string CCMSSale { get; set; }

        [JsonProperty("CashReload")]
        [DataMember]
        public string CashReload { get; set; }

        [JsonProperty("CCMSRecharge")]
        [DataMember]
        public string CCMSRecharge { get; set; }


    }
}
