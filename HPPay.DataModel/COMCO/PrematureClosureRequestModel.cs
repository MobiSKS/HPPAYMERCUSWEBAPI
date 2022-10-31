using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class PrematureClosureRequestModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("CautionAmount")]
        [DataMember]
        public decimal CautionAmount { get; set; }

        [Required]
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }
    public class PrematureClosureRequestModelOutput : BaseClassOutput
    {
    }
}
