using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetRBEDeviceIdResetRequestModelInput : BaseClass
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class GetRBEDeviceIdResetRequestModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }

        [JsonProperty("Zone")]
        [DataMember]
        public string Zone { get; set; }

        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }
    }
    

}
