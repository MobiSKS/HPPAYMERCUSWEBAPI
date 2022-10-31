using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class PCUpdateConfigureSMSAlertsModelInput : BaseClass
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
        [JsonPropertyName("TypePCConfigureSMSAlerts")]
        [DataMember]
        public List<TypePCConfigureSMSAlerts> TypePCConfigureSMSAlerts { get; set; }
    }

    public class TypePCConfigureSMSAlerts
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
      
    }

    public class PCUpdateConfigureSMSAlertsModelOutput : BaseClassOutput
    {

    }
}
