using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ConfigureAlert
{
    public class UpdateConfigureEmailAlertModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("objConfigureEmailAlert")]
        [DataMember]
        public List<ConfigureEmailAlertModelInput> objConfigureEmailAlert { get; set; }
    }

    public class ConfigureEmailAlertModelInput
    {

        [Required]
        [JsonPropertyName("ServiceId")]
        [DataMember]
        public int ServiceId { get; set; }

        [Required]
        [JsonPropertyName("AllowedStatus")]
        [DataMember]
        public int AllowedStatus { get; set; }


    }

    public class UpdateConfigureEmailAlertModelOutput : BaseClassOutput
    {

    }
}
