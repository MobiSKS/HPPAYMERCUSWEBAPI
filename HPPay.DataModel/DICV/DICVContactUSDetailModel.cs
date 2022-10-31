using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    public class DICVContactUSDetailModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class DICVContactUSDetailModelOutput : BaseClassOutput
    {
        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("MOName")]
        [DataMember]
        public string MOName { get; set; }
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }
}
