using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class ManageEditUsersModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class ManageEditUsersModelOutput : BaseClassOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }


        [JsonProperty("LastLoginDate")]
        [DataMember]
        public string LastLoginDate { get; set; }
    }
}
