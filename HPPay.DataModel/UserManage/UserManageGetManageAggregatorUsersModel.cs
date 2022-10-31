using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManageGetManageAggregatorUsersModelInput:BaseClass
    {


        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class UserManageGetManageAggregatorUsersModelOutput
    {
        [JsonProperty("UserDetails")]
        public List<UserDetails> UserDetails { get; set; }

        [JsonProperty("RoleDetails")]
        public List<RoleDetails> RoleDetails { get; set; }

    }


    public class UserDetails : BaseClassOutput
    {


        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }


        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }


        [JsonProperty("LastLogin")]
        [DataMember]
        public string LastLogin { get; set; }
    }

    public class RoleDetails
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

        [JsonProperty("AllowedAction")]
        [DataMember]
        public string AllowedAction { get; set; }
    }
}
