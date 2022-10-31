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
    public class MerchantDashboardLastBatchDeatilsModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    public class MerchantDashboardLastBatchDeatilsModelOutput : BaseClassOutput
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("BatchID")]
        [DataMember]
        public string BatchID { get; set; }

        [JsonProperty("SettlementDate")]
        [DataMember]
        public string SettlementDate { get; set; }

        [JsonProperty("Receivable_Rs_")]
        [DataMember]
        public string Receivable_Rs_ { get; set; }

        [JsonProperty("Payable")]
        [DataMember]
        public string Payable { get; set; }

    }
}
