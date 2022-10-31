using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ConfigureAlert
{
    public class GetConfigureEmailAlertsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class GetConfigureEmailAlertsOutput : BaseClassOutput
    {
        [JsonProperty("ServieId")]
        [DataMember]
        public int ServieId { get; set; }
        [JsonProperty("ServiceName")]
        [DataMember]
        public string ServiceName { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public int ServiceStatus { get; set; }

    }
}
