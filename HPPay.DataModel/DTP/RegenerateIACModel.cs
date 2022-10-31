using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DTP
{
    public class RegenerateIACModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }
    }
    public class RegenerateIACModelOutput : BaseClassOutput
    {
        
        [JsonProperty("IACID")]
        [DataMember]
        public string IACID { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("OutletName")]
        [DataMember]
        public string OutletName { get; set; }

        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }
    }
}
