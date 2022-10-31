using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class ManageAPIRoleListModelInput : BaseClass
    {
        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }
    }


    public class ManageAPIRoleListModelOutput : BaseClassOutput
    {
        [JsonProperty("ID")]
        [DataMember]
        public int ID { get; set; }

        [JsonProperty("RoleName")]
        [DataMember]

        public string RoleName { get; set; }

        [JsonProperty("RoleDescription")]
        [DataMember]

        public string RoleDescription { get; set; }
    }
}
