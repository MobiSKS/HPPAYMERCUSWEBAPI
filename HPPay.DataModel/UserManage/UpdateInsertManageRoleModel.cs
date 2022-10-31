using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UpdateInsertManageRoleModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RoleId")]
        [DataMember]
        public int RoleId { get; set; }

        [Required]
        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjUpdate")]
        [DataMember]

        public List<TypeUpdateInsertManageUsersTable> ObjUpdate { get; set; }
    }
    public class TypeUpdateInsertManageUsersTable
    {
        [Required]
        [JsonPropertyName("MenuId")]
        [DataMember]
        public string MenuId { get; set; }

        [Required]
        [JsonPropertyName("AllowedAction")]
        [DataMember]
        public string AllowedAction { get; set; }

    }
    public class UpdateInsertManageRoleModelOutput : BaseClassOutput
    {

    }

}
