using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.State
{
    public class GetStateModelInput : BaseClass
    {
        [JsonPropertyName("CountryID")]
        [DataMember]
        public int CountryID { get; set; }
    }
    public class GetStateModelOutput
    {
        [JsonProperty("CountryID")]
        [DataMember]
        public int CountryID { get; set; }

        [JsonProperty("StateID")]
        [DataMember]
        public int StateID { get; set; }

        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }

        [JsonProperty("StateCode")]
        [DataMember]
        public string StateCode { get; set; }


        [JsonProperty("StateShortName")]
        [DataMember]
        public string StateShortName { get; set; }
    }


    public class DeleteStateModelInput : BaseClass
    {
        [JsonPropertyName("StateID")]
        [DataMember]
        public int StateID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteStateModelOutput : BaseClassOutput
    {

    }
}
