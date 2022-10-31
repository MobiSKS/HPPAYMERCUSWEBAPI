using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManageDeleteManageUsersModelInput : BaseClass
    {      
      
        [JsonPropertyName("TypeDeleteUserManage")]
        [DataMember]
        public List<TypeDeleteUserManage> TypeDeleteUserManage { get; set; }
    }

    public class TypeDeleteUserManage
    {
        
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
       
    }

    public class UserManageDeleteManageUsersModelOutput : BaseClassOutput
    {

    }
}

