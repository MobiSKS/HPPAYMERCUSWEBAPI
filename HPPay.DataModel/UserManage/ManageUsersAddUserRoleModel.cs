using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class ManageUsersAddUserRoleModelInput : BaseClass
    {
        [JsonPropertyName("UserRole")]
        [DataMember]
        public int UserRole { get; set; }

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }



        [JsonPropertyName("TypeManageUsersAddUserRole")]
        [DataMember]
        public List<TypeManageUsersAddUserRole> TypeManageUsersAddUserRole { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }

    public class TypeManageUsersAddUserRole
    {

        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }

        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }

    }
    public class ManageUsersAddUserRoleModelOutput : BaseClassOutput
    {

    }
}
