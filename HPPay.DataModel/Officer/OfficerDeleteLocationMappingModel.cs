using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{
    public class OfficerDeleteLocationMappingModelInput : BaseClass
    {
         
        

        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }

        
        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

       

    }

    public class OfficerDeleteLocationMappingModelOutput : BaseClassOutput
    {

    }

   
}
