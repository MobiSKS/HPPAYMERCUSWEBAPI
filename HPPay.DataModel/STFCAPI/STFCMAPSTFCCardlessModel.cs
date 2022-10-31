using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFCAPI
{
    public class STFCMAPSTFCCardlessModelInput:STFCAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Invalid Mobile Number.")]
        [JsonPropertyName("Mobile")]
        [DataMember]
        public string Mobile { get; set; }


        [Required]
        [JsonPropertyName("ManipulationType")]
        [DataMember]
        public string ManipulationType { get; set; }
    }

    public class STFCMAPSTFCCardlessModelOutput : STFCAPIBaseClassOutput
    {

    }
}

