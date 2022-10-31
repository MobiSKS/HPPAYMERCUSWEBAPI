using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{
     
    public class MerchantGetReasonListModelInput : BaseClass
    {

    }
    public class MerchantGetReasonListModelOutput
    {
        [JsonProperty("ReasonId")]
        [DataMember]
        public int ReasonId { get; set; }

        [JsonProperty("ReasonName")]
        [DataMember]
        public string ReasonName { get; set; }
    }
}
