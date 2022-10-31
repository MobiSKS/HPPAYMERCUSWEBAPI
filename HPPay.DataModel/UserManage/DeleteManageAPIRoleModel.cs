using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class DeleteManageAPIRoleModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TypeRoleNameAndRoleDescriptionMapping")]
        [DataMember]
        public List<TypeDeleteRoleNameAndRoleDescriptionMappings> TypeRoleNameAndRoleDescriptionMapping { get; set; }
    }

    public class TypeDeleteRoleNameAndRoleDescriptionMappings 
    {

        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }


        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }

    }

    public class DeleteManageAPIRoleModelOutput : BaseClassOutput
    {

    }
}
