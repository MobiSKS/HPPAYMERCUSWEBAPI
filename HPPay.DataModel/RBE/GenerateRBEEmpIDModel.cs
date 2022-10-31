using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class GenerateRBEEmpIDModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("LocationId")]
        [DataMember]
        public Int16 LocationId { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }


    }

    public class GenerateRBEEmpIDModelOutput
    {

        [JsonProperty("EMPId")]
        [DataMember]
        public string EMPId { get; set; }

    }
}
