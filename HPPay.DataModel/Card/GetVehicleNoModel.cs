using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class GetVehicleNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }
    }
    public class GetVehicleNoModelOutput : BaseClassOutput
    {

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

    }
}
