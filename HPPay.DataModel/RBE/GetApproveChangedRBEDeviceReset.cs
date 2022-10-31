using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetApproveChangedRBEDeviceResetModelInput : BaseClass
    {
        [JsonPropertyName("ApprovalStatus")]
        [DataMember]
        public string ApprovalStatus { get; set; }

        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }

    public class GetApproveChangedRBEDeviceResetModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }


        [JsonProperty("RBEDeviceReset")]
        [DataMember]
        public string RBEDeviceReset { get; set; }
    }
}
