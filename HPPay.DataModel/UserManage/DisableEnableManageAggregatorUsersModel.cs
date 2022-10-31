using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class DisableEnableManageAggregatorUsersModelInput : BaseClass
    {
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [JsonPropertyName("LoginKey")]
        [DataMember]
        public string LoginKey { get; set; }
    }

    public class DisableEnableManageAggregatorUsersModelOutput : BaseClassOutput
    {
        
    }
}
