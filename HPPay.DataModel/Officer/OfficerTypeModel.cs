using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{

    public class GetOfficerSubTypeModelInput : BaseClass
    {
         
    }
    public class GetOfficerSubTypeModelOutput
    {
        [JsonProperty("OfficerSubTypeId")]
        [DataMember]
        public int OfficerSubTypeId { get; set; }

        [JsonProperty("OfficerSubTypeName")]
        [DataMember]
        public string OfficerSubTypeName { get; set; }
        
    }

    public class GetOfficerTypeModelInput : BaseClass
    {
        [JsonPropertyName("OfficerSubTypeId")]
        [DataMember]
        public int OfficerSubTypeId { get; set; }
    }
    public class GetOfficerTypeModelOutput
    {
        [JsonProperty("OfficerTypeID")]
        [DataMember]
        public int OfficerTypeID { get; set; }

        [JsonProperty("OfficerTypeName")]
        [DataMember]
        public string OfficerTypeName { get; set; }

        [JsonProperty("OfficerTypeShortName")]
        [DataMember]
        public string OfficerTypeShortName { get; set; }
    }
}
