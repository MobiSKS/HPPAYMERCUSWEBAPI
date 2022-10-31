using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ConfigureAlert
{
    public class UpdateConfigureSMSAlertsModelInput: BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("TypeConfigureSMSAlerts")]
        [DataMember]
        public List<TypeConfigureSMSAlerts> TypeConfigureSMSAlerts { get; set; }
    }

    public class TypeConfigureSMSAlerts
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("TransactionID")]
        [DataMember]
        public int TransactionID { get; set; }

        public int StatusId { get; set; }
      //  public string Designation { get; set; }
    }

    public class UpdateConfigureSMSAlertsModelOutput : BaseClassOutput
    {
        
    }
}
