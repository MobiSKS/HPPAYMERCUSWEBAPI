using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetMappedParentMerchantIdModelInput : BaseClass
    {
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }
    }

    public class GetMappedParentMerchantIdModelOutput : BaseClassOutput
    {
        [JsonProperty("RetailOutletId")]
        [DataMember]
        public string RetailOutletId { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }
    }
}
