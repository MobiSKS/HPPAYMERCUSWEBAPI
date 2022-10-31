using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    
    public class GetAvailityDICVOTCCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }
    }

    public class GetAvailityDICVOTCCardModelOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
}
