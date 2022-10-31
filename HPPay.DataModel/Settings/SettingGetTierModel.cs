using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{
    public class SettingGetTierModelInput : BaseClass
    {

    }
    public class SettingGetTierModelOutput
    {
        [JsonProperty("TierId")]
        [DataMember]
        public int TierId { get; set; }

        [JsonProperty("TierName")]
        [DataMember]
        public string TierName { get; set; }
    }
}
