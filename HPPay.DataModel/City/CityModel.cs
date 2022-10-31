using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.City
{

    public class GetCityModelInput : BaseClass
    {

    }
    public class GetCityModelOutput
    {
        [JsonProperty("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [JsonProperty("CityId")]
        [DataMember]
        public int CityId { get; set; }

        [JsonProperty("CityCode")]
        [DataMember]
        public string CityCode { get; set; }

        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }


        [JsonProperty("CityShortName")]
        [DataMember]
        public string CityShortName { get; set; }
    }

    public class DeleteCityModelInput : BaseClass
    {
        [JsonPropertyName("CityID")]
        [DataMember]
        public int CityID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteCityModelOutput : BaseClassOutput
    {

    }
}
