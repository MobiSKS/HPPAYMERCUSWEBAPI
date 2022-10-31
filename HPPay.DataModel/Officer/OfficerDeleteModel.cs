using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{
        
    public class DeleteOfficerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("OfficerId")]
        [DataMember]
        public int OfficerId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class DeleteOfficerModelOutput : BaseClassOutput
    {

    }

    
}
