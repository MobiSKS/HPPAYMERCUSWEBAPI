using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserApprovalRejectionModelInput : BaseClass
    {
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("TypeApprovalRejectionList")]
        [DataMember]
        public List<TypeApprovalRejectionList> TypeApprovalRejectionList { get; set; }

    }
    public class TypeApprovalRejectionList
    {

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }
    public class UserApprovalRejectionModelOutput : BaseClassOutput
    {
        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }

    }
}
