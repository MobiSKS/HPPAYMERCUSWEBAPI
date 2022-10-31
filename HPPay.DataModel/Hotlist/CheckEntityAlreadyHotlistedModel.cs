using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Hotlist
{
    public class CheckEntityAlreadyHotlistedModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public Int32 EntityTypeId { get; set; }

        [Required]
        [JsonPropertyName("EntityIdVal")]
        [DataMember]
        public string EntityIdVal { get; set; }
    }

    public class CheckEntityAlreadyHotlistedModelOutput : BaseClassOutput
    {
    }
}
