using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class ApproveRejectChangedRbeMobileModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ExistingMobile")]
        [DataMember]
        public string ExistingMobile { get; set; }

        [Required]
        [JsonPropertyName("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

    }
    public class ApproveRejectChangedRbeMobileModelOutput : BaseClassOutput
    {

    }
}
