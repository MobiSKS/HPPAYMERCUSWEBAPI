using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetAddAPIRoleAndPermissionsModelInput : BaseClass
    {

    }

    public class GetAddAPIRoleAndPermissionsModelOutput : BaseClassOutput
    {

        [JsonProperty("ApiID")]
        [DataMember]
        public string ApiID { get; set; }

        [JsonProperty("ApiName")]
        [DataMember]
        public string ApiName { get; set; }
    }
}