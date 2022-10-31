using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetMerchantStatusModelInput : BaseClass
    {

    }

    public class MerchantGetMerchantStatusModelOutput
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}
