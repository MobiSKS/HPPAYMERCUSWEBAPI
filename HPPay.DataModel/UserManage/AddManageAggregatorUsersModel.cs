using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class AddManageAggregatorUsersModelInput : BaseClass
    {
    }
    public class AddManageAggregatorUsersModelOutput
    {
        [JsonProperty("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonProperty("RoleDescription")]
        [DataMember]

        public string RoleDescription { get; set; }

        [JsonProperty("ControlType")]
        [DataMember]

        public string ControlType { get; set; }
    }
}
