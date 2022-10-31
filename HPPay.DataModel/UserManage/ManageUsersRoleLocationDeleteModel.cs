using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.UserManage
{
    public class ManageUsersRoleLocationDeleteModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("RoleId")]
        [DataMember]
        public string RoleId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("TypeManageUsersAddUserRole")]
        [DataMember]
        public List<TypeManageUsersAddUserRole> TypeManageUsersAddUserRole { get; set; }
    }

    public class ManageUsersRoleLocationDeleteModelOutput : BaseClassOutput
    {
    }
}
