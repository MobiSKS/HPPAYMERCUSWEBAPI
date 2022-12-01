using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Login
{
  

    public class GetLoginModelInput : BaseClass
    {

        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }
    }

    public class GetLoginModelOutput : BaseClassOutput
    {

        [JsonProperty("LoginType")]
        [DataMember]
        public string LoginType { get; set; }


        [JsonProperty("UserId")]
        [DataMember]
        public string UserId { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("UserRole")]
        [DataMember]
        public string UserRole { get; set; }


        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }


        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


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

        [JsonProperty("Token")]
        [DataMember]
        public string Token { get; set; }

        [JsonProperty("MobileUserRole")]
        [DataMember]
        public string MobileUserRole { get; set; }

        [JsonProperty("ProfileImg")]
        [DataMember]
        public string ProfileImg { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public string SBUTypeId { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonProperty("UserSubType")]
        [DataMember]
        public string UserSubType { get; set; }

        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonProperty("FirstTimeLoginStatus")]
        [DataMember]
        public string FirstTimeLoginStatus { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }
    }
}
