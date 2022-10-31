using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class GetApprovedMerchantReactivationStatusModelInput:BaseClass
    {

    }

    public class GetApprovedMerchantReactivationStatusModelOutput:BaseClassOutput
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}

