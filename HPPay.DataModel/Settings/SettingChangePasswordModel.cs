using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Settings
{
    public class SettingChangePasswordModelInput:BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonPropertyName("OldPassword")]
        [DataMember]
        public string OldPassword { get; set; }

        [JsonPropertyName("NewPassword")]
        [DataMember]
        public string NewPassword { get; set; }

        [JsonPropertyName("ConfirmNewPassword")]
        [DataMember]
        public string ConfirmNewPassword { get; set; }

    }

    public class SettingChangePasswordModelOutput : BaseClassOutput
    {
     
    }
    }
