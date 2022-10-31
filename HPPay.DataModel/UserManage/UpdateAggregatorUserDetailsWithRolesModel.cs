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
    public class UpdateAggregatorUserDetailsWithRolesModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("TypeUpdateManageAggregatorUsers")]
        [DataMember]
        public List<TypeUpdateManageAggregatorUsers> TypeUpdateManageAggregatorUsers { get; set; }
    }

    public class TypeUpdateManageAggregatorUsers
    {

        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }

        [JsonPropertyName("ControlType")]
        [DataMember]
        public string ControlType { get; set; }

        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public string StatusFlag { get; set; }
    }
    public class UpdateAggregatorUserDetailsWithRolesModelOutput : BaseClassOutput
    {

    }
}
