using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Settings
{
    public class SettingUpdateMobileNoAndEmailIdModelInput: BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
        [Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }
    public class SettingUpdateMobileNoAndEmailIdModelOutput : BaseClassOutput
    {
    }
}
