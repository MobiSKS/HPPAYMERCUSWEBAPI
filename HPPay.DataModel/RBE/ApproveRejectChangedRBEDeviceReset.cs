using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class ApproveRejectChangedRBEDeviceResetModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

    }
    public class ApproveRejectChangedRBEDeviceResetModelOutput : BaseClassOutput
    {

    }
}
