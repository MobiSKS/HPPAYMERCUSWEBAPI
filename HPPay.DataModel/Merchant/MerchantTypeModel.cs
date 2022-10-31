using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class GetMerchantTypeModelInput : BaseClass
    {

    }
    public class GetMerchantTypeModelOutput
    {
        [JsonProperty("MerchantTypeCode")]
        [DataMember]
        public int MerchantTypeCode { get; set; }

        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }
    }
}
