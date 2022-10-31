using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public class GetPEKModelInput:BaseClass

    {
        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }


        [Required]
        [JsonPropertyName("PublicKey")]
        [DataMember]
        public string PublicKey { get; set; }

        
    }

    public class GetPEKModelOutput : AGSBaseClassOutput

    {
        [JsonProperty("PEK")]
        [DataMember]
        public string PEK { get; set; }

    }
}
