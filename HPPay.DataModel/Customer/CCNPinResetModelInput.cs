using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.Customer
{
    public class CCNPinResetModelInput:BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]

        public string CustomerID { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
         
        [JsonPropertyName("Type")]
        [DataMember]
        public string Type { get; set; }
        
    }

    public class CCNPinResetModelOutput:BaseClassOutput
    {
        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("CIN")]
        [DataMember]
        public Int64 CIN { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("Pin")]
        [DataMember]
        public string Pin { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]

        public string CustomerID { get; set; }

    }
}
