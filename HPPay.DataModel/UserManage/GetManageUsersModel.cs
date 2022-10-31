using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetManageUsersModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonPropertyName("LastLoginTime")]
        [DataMember]
        public string LastLoginTime { get; set; }

        [JsonPropertyName("UserRole")]
        [DataMember]
        public string UserRole { get; set; }

        [JsonPropertyName("ShowDisabled")]
        [DataMember]
        public int ShowDisabled { get; set; }

        [JsonPropertyName("ForAll")]
        [DataMember]
        public string ForAll { get; set; }
    }
    public class GetManageUsersModelOutput : BaseClassOutput
    {
        [JsonProperty ("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty ("Email")]
        [DataMember]

        public string Email { get; set; }

        [JsonProperty("LastLoginTime")]
        [DataMember]

        public string LastLoginTime { get; set; }

        [JsonProperty ("UserRole")]
        [DataMember]

        public string UserRole { get; set; }


    }
}
