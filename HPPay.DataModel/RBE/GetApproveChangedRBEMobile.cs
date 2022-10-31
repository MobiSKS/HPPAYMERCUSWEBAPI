using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
   
    public class GetApproveChangedRBEMobileModelInput : BaseClass
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

    public class GetApproveChangedRBEMobileModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [JsonProperty("ExistingMobileNo")]
        [DataMember]
        public string ExistingMobileNo { get; set; }

        [JsonProperty("NewMobileNo")]
        [DataMember]
        public string NewMobileNo { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("ChangeRBEMobile")]
        [DataMember]
        public string ChangeRBEMobile { get; set; }
    }
}
