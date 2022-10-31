using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserCreationApprovalModelInput : BaseClass
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class UserCreationApprovalModelOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName")]
        [DataMember]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("SubLevelName")]
        [DataMember]
        public string SubLevelName { get; set; }

        [JsonProperty("Comments")]
        [DataMember]
        public string Comments { get; set; }
    }
}
