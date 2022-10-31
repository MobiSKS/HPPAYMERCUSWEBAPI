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
    public class PCDNDConfigureSMSAlertsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class PCDNDConfigureSMSAlertsModelOutput : BaseClassOutput
    {

    }

}
