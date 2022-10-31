using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Country
{

    public class GetCountryModelInput : BaseClass
    {

    }
    public class GetCountryModelOutput
    {
        [JsonPropertyName("CountryID")]
        [DataMember]
        public int CountryID { get; set; }

        [JsonPropertyName("CountryName")]
        [DataMember]
        public string CountryName { get; set; }

        [JsonPropertyName("CountryShortName")]
        [DataMember]
        public string CountryShortName { get; set; }
    }

    public class DeleteCountryModelInput : BaseClass
    {
        [JsonPropertyName("CountryID")]
        [DataMember]
        public int CountryID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteCountryModelOutput : BaseClassOutput
    {

    }
}
