using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{

    public class SettingGetRoleModelInput : BaseClass
    {

    }
    public class SettingGetRoleModelOutput
    {
        [JsonProperty("RoleId")]
        [DataMember] 
        public int RoleId { get; set; }

        [JsonProperty("RoleName")]
        [DataMember]
        public string RoleName { get; set; }
    }
}
