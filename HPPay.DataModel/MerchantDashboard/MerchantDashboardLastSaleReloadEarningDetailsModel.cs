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
    public class MerchantDashboardLastSaleReloadEarningDetailsModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }
    public class MerchantDashboardLastSaleReloadEarningDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }

        [JsonProperty("Reload_Rs")]
        [DataMember]
        public string Reload_Rs { get; set; }

        [JsonProperty("Sale_Rs")]
        [DataMember]
        public string Sale_Rs { get; set; }

        [JsonProperty("Earning_Rs")]
        [DataMember]
        public string Earning_Rs { get; set; }

       
    }
}
