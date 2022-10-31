using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Settings
{
    public class GetCPStatuModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("PageName")]
        [DataMember]
        public string PageName { get; set; } 
    }
    public class GetCPStatuModelOutPut
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; } 

    }
}

