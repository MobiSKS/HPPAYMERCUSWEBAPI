using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetTerminalTypeModelInput : BaseClass
    {

    }

    public class MerchantGetTerminalTypeModelOutput
    {
        [JsonProperty("Id")]
        [DataMember]
        public string Id { get; set; }

        [JsonProperty("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }

    }
}
