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
    public class UpdateUserRoleLocationModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


        //[Required]
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("UserRole")]
        [DataMember]
        public int UserRole { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("TypeManageUsersAddUserRoleWithStatusFlag")]
        [DataMember]
        public List<TypeManageUsersAddUserRoleWithStatusFlag> TypeManageUsersAddUserRoleWithStatusFlag { get; set; }
    }
    public class TypeManageUsersAddUserRoleWithStatusFlag
    {

        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }

        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }

    }

    public class UpdateUserRoleLocationModelOutput : BaseClassOutput
    {

    }
}
