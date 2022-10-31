using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace HPPay.DataModel.Settings
{
    public class SettingGetRecordTypeModelInput : BaseClass
    {

    }
    public class SettingGetRecordTypeModelOutput
    {
        [JsonProperty("EntityId")]
        [DataMember]
        public int EntityId { get; set; }


        [JsonProperty("EntityName")]
        [DataMember]
        public string EntityName { get; set; }
    }
}
