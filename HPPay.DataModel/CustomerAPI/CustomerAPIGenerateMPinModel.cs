using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGenerateMPinModelInput : CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class CustomerAPIGenerateMPinModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("MPIN")]
        [DataMember]
        public string MPIN { get; set; }
    }
}
