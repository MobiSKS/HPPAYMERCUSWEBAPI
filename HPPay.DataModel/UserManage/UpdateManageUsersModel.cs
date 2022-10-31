using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UpdateManageUsersModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]

        public string UserName { get; set; }

        [JsonPropertyName("Actions")]
        [DataMember]

        public string Actions { get; set; }
    }
    public class UpdateManageUsersModelOutput : BaseClassOutput
    {
       
    }
}
