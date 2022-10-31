using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class UpdateServiveOnCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [Required]
        [JsonPropertyName("Serviceid")]
        [DataMember]
        public Int32 Serviceid { get; set; }

        [Required]
        [JsonPropertyName("Flag")]
        [DataMember]
        public int Flag { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class UpdateServiveOnCardModelOutput : BaseClassOutput
    {

    }
}
