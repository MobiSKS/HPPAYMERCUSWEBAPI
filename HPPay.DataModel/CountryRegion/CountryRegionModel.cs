using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CountryRegion
{
    

    public class GetCountryRegionModelInput : BaseClass
    {
        [JsonPropertyName("ZoneID")]
        [DataMember]
        public int ZoneID { get; set; }
    }
    public class GetCountryRegionModelOutput
    {
        [JsonProperty("ZoneID")]
        [DataMember]
        public int ZoneID { get; set; }

        [JsonProperty("RegionID")]
        [DataMember]
        public int RegionID { get; set; }

        [JsonProperty("RegionCode")]
        [DataMember]
        public string RegionCode { get; set; }

        [JsonProperty("RegionName")]
        [DataMember]
        public string RegionName { get; set; }

        [JsonProperty("RegionShortName")]
        [DataMember]
        public string RegionShortName { get; set; }
    }

    public class DeleteCountryRegionModelInput : BaseClass
    {
        [JsonPropertyName("RegionID")]
        [DataMember]
        public int RegionID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteCountryRegionModelOutput : BaseClassOutput
    {

    }
}
