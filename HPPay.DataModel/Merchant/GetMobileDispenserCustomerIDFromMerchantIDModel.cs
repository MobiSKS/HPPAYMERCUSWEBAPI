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
    public class GetMobileDispenserCustomerIDFromMerchantIDModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    public class GetMobileDispenserCustomerIDFromMerchantIDModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
}
