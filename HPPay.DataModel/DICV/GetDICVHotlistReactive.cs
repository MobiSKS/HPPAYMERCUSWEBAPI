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
    public class GetDICVHotlistReactiveModelInput :BaseClass
    {
        [Required]
        [JsonPropertyName("EntitytypeId")]
        [DataMember]
        public string EntitytypeId { get; set; }


    }

    public class GetDICVHotlistReactiveModelOutput
    {

        [JsonProperty("ReasonId")]
        [DataMember]
        public string ReasonId { get; set; }

        [JsonProperty("ReasonName")]
        [DataMember]
        public string ReasonName { get; set; }


    }
}
