using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Settings
{
    public class SettingForgetPasswordModelInput: BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonPropertyName("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

    }
    public class SettingForgetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }
}
