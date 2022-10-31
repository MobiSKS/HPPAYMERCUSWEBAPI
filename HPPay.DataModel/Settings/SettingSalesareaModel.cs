using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Settings
{

    public class SettingGetSalesareaModelInput : BaseClass
    {
        [JsonPropertyName("RegionID")]
        [DataMember]
        public int RegionID { get; set; }
    }

    public class SettingGetSalesAreaByMultipleRegionModelInput : BaseClass
    {
        [JsonPropertyName("RegionID")]
        [DataMember]
        public string RegionID { get; set; }
    }
    public class SettingGetSalesareaModelOutput
    {
        [JsonProperty("RegionID")]
        [DataMember]
        public int RegionID { get; set; }

        [JsonProperty("SalesAreaID")]
        [DataMember]
        public int SalesAreaID { get; set; }

        [JsonProperty("SalesAreaName")]
        [DataMember]
        public string SalesAreaName { get; set; }
    }
}
