using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{
    public class SettingGetEntityModelInput : BaseClass
    {

    }
    public class SettingGetEntityModelOutput
    {
        [JsonProperty("EntityId")]
        [DataMember]
        public int EntityId { get; set; }

        [JsonProperty("EntityName")]
        [DataMember]
        public string EntityName { get; set; }
    }
}
