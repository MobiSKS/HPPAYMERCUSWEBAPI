using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetEditManageAPIRoleModelInput : BaseClass
    {

        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }


    }

    public class GetEditManageAPIRoleModelOutput 
    {

        [JsonProperty("tblThirdPartyApiMainAndSubLevelRoleMap")]
        public List<GetThirdPartyApiMainAndSubLevelRoleMap> tblThirdPartyApiMainAndSubLevelRoleMap { get; set; }

        [JsonProperty("tblThirdPartyApiDetails")]
        public List<GetThirdPartyApiDetails> tblThirdPartyApiDetails { get; set; }
    }

    public class GetThirdPartyApiMainAndSubLevelRoleMap
    {
        [JsonProperty("SubLevelId")]
        [DataMember]
        public string SubLevelId { get; set; }


        [JsonProperty("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonProperty("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }
    }


    public class GetThirdPartyApiDetails
    {
        [JsonProperty("ApiID")]
        [DataMember]
        public string ApiID { get; set; }


        [JsonProperty("ApiName")]
        [DataMember]
        public string ApiName { get; set; }

        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }

    }
}
