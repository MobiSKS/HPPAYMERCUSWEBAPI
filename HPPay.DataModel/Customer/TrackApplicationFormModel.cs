using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class TrackApplicationFormModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
    }
    public class TrackApplicationFormModelOutput : BaseClassOutput
    {
       
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }
    }
}
