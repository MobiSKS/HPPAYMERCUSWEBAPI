using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class ConfigureSMSAlertsModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("TransactionID")]
        [DataMember]
        public string TransactionID { get; set; }


        [Required]
        [JsonPropertyName("Action")]
        [DataMember]
        public string Action { get; set; }

    }


    public class ConfigureSMSAlertsModelOutput : BaseClassOutput
    {
        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }
    }

}
