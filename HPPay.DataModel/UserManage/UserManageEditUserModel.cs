using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManageEditUserModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class UserManageEditUserModelOutput
    {
        [JsonProperty("mstKeyDetail")]
        public List<GetmstKeyDetail> mstKeyDetail { get; set; }



        [JsonProperty("tblMainAndSubLevel")]
        public List<GetRoleMap> tblMainAndSubLevel { get; set; }

    }

    public class GetmstKeyDetail : BaseClassOutput
    {
        [JsonProperty("LoginKey")]
        [DataMember]
        public string LoginKey { get; set; }


        [JsonProperty("UserType")]
        [DataMember]
        public string UserType { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("LastLogin")]
        [DataMember]
        public string LastLogin { get; set; }

    }

    public class GetRoleMap
    {

        [JsonProperty("RoleId")]
        [DataMember]
        public int RoleId { get; set; }


        [JsonProperty("UserRole")]
        [DataMember]
        public string UserRole { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public string RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("ZonalOfficeID")]
        [DataMember]
        public string ZonalOfficeID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

    }

}
