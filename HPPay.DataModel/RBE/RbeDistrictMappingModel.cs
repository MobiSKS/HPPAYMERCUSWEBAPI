using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.RBE
{
    public class RbeDistrictMappingModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("RBEID")]
        [DataMember]
        public int RBEID { get; set; }

        [JsonPropertyName("Typedistrictmapping")]
        [DataMember]
        public List<Typedistrictmapping> Typedistrictmapping { get; set; }

    }

    public class Typedistrictmapping
    {
        [Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }

    }
    public class RbeDistrictMappingModelOutput:BaseClassOutput
    {

    }
}
