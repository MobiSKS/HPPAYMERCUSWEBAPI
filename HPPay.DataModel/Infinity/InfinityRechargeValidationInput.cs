using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Infinity
{
    public class InfinityRechargeValidationInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
    }
    public class InfinityRechargeValidationOutput : BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }
    }
}
