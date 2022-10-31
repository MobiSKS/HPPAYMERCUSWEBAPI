using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class UpdateCCMSBalAlertConfigurationModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        
        
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }
    }

    public class UpdateCCMSBalAlertConfigurationModelOutput : BaseClassOutput
    {
       
    }
}
