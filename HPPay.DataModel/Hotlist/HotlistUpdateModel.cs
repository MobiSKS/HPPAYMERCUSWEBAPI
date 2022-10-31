using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Hotlist
{
    public class HotlistUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public Int32 EntityTypeId { get; set; }

        [Required]
        [JsonPropertyName("EntityIdVal")]
        [DataMember]
        public string EntityIdVal { get; set; }

        [Required]
        [JsonPropertyName("ActionId")]
        [DataMember]
        public Int32 ActionId { get; set; }

        [Required]
        [JsonPropertyName("ReasonId")]
        [DataMember]
        public string ReasonId { get; set; }

        [JsonPropertyName("ReasonDetails")]
        [DataMember]
        public string ReasonDetails { get; set; }

        [Required]
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class HotlistUpdateModelOutput : BaseClassOutput
    {

        [JsonProperty("ActionName")]
        [DataMember]
        public string ActionName { get; set; }

        [JsonProperty("EntityTypeValue")]
        [DataMember]
        public string EntityTypeValue { get; set; }
    }
}
