using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetUserRoleModelInput :BaseClass
    {
        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }
    }

    public class GetUserRoleModelOutput : BaseClassOutput
    {
        [JsonProperty("ID")]
        [DataMember]
        public string ID { get; set; }

        [JsonProperty("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonProperty("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }
    }

}
