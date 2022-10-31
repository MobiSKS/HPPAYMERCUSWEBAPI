using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantGetSBUModelInput : BaseClass
    {

    }
    public class MerchantGetSBUModelOutput
    {
        [JsonProperty("SBUId")]
        [DataMember]
        public int SBUId { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }
    }
}
