using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerCardRequestEntryModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RegionalId")]
        [DataMember]
        public Int32 RegionalId { get; set; }

        [Required]
        [JsonPropertyName("NoofCards")]
        [DataMember]
        public Int32 NoofCards { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class CustomerCardRequestEntryModelOutput : BaseClassOutput
    {
        
    }

}
