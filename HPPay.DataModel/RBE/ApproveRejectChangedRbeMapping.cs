using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class ApproveRejectChangedRbeMappingModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("PreRBEUserName")]
        [DataMember]
        public string PreRBEUserName { get; set; }

        [Required]
        [JsonPropertyName("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }
        
    }
    public class ApproveRejectChangedRbeMappingModelOutput : BaseClassOutput
    {
        
    }
}
