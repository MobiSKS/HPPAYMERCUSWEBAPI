using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetUserRolesAndRegionsModelInput:BaseClass
    {
    }
    public class GetUserRolesAndRegionsModelOutput
    {
        [JsonProperty("Locations")]
        public List<UserRegionsModelOutput> Locations { get; set; }

        [JsonProperty("UserRoles")]
        public List<UserRolesModelOutput> UserRoles { get; set; }
    }
    public class UserRolesModelOutput
    {
        [JsonProperty("ID")]
        [DataMember]
        public int ID { get; set; }

        [JsonProperty("UserRole")]
        [DataMember]

        public string UserRole { get; set; }
    }
    public class UserRegionsModelOutput
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
    

