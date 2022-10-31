using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class RoleNameAndRoleDescriptionMappingModelInput : BaseClass
    {
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }



        [JsonPropertyName("TypeRoleNameAndRoleDescriptionMapping")]
        [DataMember]
        public List<TypeRoleNameAndRoleDescriptionMapping> TypeRoleNameAndRoleDescriptionMapping { get; set; }
    }

    public class TypeRoleNameAndRoleDescriptionMapping
    {

        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }

    }
    public class RoleNameAndRoleDescriptionMappingModelOutput : BaseClassOutput
    {

    }
}
