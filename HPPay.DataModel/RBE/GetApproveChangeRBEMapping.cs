using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetApproveChangeRBEMappingModelInput : BaseClass
    {
        [JsonPropertyName("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class GetApproveChangeRBEMappingModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("NewRBEUser")]
        [DataMember]
        public string NewRBEUser { get; set; }

        [JsonProperty("NewUserName")]
        [DataMember]
        public string NewUserName { get; set; }

        [JsonProperty("PreRBEUser")]
        [DataMember]
        public string PreRBEUser { get; set; }

        [JsonProperty("PreUserName")]
        [DataMember]
        public string PreUserName { get; set; }

        [JsonProperty("FromLocation")]
        [DataMember]
        public string FromLocation { get; set; }

        [JsonProperty("ToLocation")]
        [DataMember]
        public string ToLocation { get; set; }

        [JsonProperty("status")]
        [DataMember]
        public string status { get; set; }

        [JsonProperty("ChangeRBE")]
        [DataMember]
        public string ChangeRBE { get; set; }
    }
}
