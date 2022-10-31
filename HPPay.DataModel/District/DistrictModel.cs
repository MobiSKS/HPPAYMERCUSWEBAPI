using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.District
{

    public class GetDistrictModelInput : BaseClass
    {
        [JsonPropertyName("StateID")]
        [DataMember]
        public int StateID { get; set; }
    }

    public class GetDistrictByMultipleStateIDModelInput : BaseClass
    {
        [JsonPropertyName("StateID")]
        [DataMember]
        public string StateID { get; set; }
    }
    public class GetDistrictModelOutput
    {
        [JsonPropertyName("StateID")]
        [DataMember]
        public int StateID { get; set; }

        [JsonPropertyName("StateName")]
        [DataMember]
        public string StateName { get; set; }

        [JsonPropertyName("DistrictID")]
        [DataMember]
        public int DistrictID { get; set; }

        [JsonPropertyName("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }

        [JsonPropertyName("DistrictShortName")]
        [DataMember]
        public string DistrictShortName { get; set; }

        [JsonPropertyName("DistrictCode")]
        [DataMember]
        public string DistrictCode { get; set; }
    }

    public class DeleteDistrictModelInput : BaseClass
    {
        [JsonPropertyName("DistrictID")]
        [DataMember]
        public int DistrictID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteDistrictModelOutput : BaseClassOutput
    {

    }
}
