using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{

    public class SettingGetProductModelInput : BaseClass
    {

    }
    public class SettingGetProductModelOutput
    {
        [JsonProperty("ProductID")]
        [DataMember]
        public int ProductID { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }
    }
}
