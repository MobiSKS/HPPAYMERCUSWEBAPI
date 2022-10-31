using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.M2PAPI
{
    public class MAPM2PCardlessModelInput:M2PAPIBaseClassInput
    {


        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [Required]
        [JsonPropertyName("Mobile")]
        [DataMember]
        public string Mobile { get; set; }


        [Required]
        [JsonPropertyName("ManipulationType")]
        [DataMember]
        public string ManipulationType { get; set; }
    }

    public class MAPM2PCardlessModelOutput : M2PAPIBaseClassOutput
    {

    }
}
