using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace HPPay.DataModel.UserManage
{
    public class UserManageGetUserCreationDetailsModelInput:BaseClass
    {

    }

    public class UserManageGetUserCreationDetailsModelOutput
    {
        [JsonProperty("tblMainSubLevelRoleMap")]
        public List<GetMainAndSubLevelRole> tblMainSubLevelRoleMap { get; set; }



        [JsonProperty("tblUserCreation")]
        public List<GetUserCreation> tblUserCreation { get; set; }

    }
    public class GetMainAndSubLevelRole
    {
        [JsonProperty("ID")]
        [DataMember]
        public int ID { get; set; }

        [JsonProperty("UserRole")]
        [DataMember]

        public string RoleName { get; set; }
    }
    public class GetUserCreation
    {
        [JsonProperty("ZonalOfficeID")]
        [DataMember]
        public int ZonalOfficeID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]

        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
       public string RegionalOfficeName { get; set; }
    }
}
