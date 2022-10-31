using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class ManageAggregatorUsersModelInput : BaseClass
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
    }
    public class ManageAggregatorUsersModelOutput : BaseClassOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }



        [JsonProperty("LastLoginTime")]
        [DataMember]

        public string LastLoginTime { get; set; }

        [JsonProperty("Email")]
        [DataMember]


        public string Email { get; set; }

        
        [JsonProperty("WebUiRole")]
        [DataMember]

        public string WebUiRole { get; set; }


        [JsonProperty("ApiRole")]
        [DataMember]

        public string ApiRole { get; set; }

    }
}
