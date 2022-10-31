using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetAddManageUsersModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }
    public class GetAddManageUsersModelOutput
    {
        [JsonProperty("KeyDeatil")]
        public List<mstKeyDetail> KeyDeatil { get; set; }

        [JsonProperty("Location")]
        public List<ZonalandRegionalLocation> Location { get; set; }
    }
    public class mstKeyDetail
    {
        [JsonProperty("LoginKey")]
        [DataMember]
        public string LoginKey { get; set; }

        [JsonProperty("Email")]
        [DataMember]

        public string Email { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]

        public string CreatedDate { get; set; }

        [JsonProperty("LastLoginDate")]
        [DataMember]

        public string LastLoginDate { get; set; }
    }
    public class ZonalandRegionalLocation
    {
        [JsonProperty("UserRole")]
        [DataMember]
        public string UserRole { get; set; }

        [JsonProperty("Location")]
        [DataMember]

        public string Location { get; set; }

       


    }
}
