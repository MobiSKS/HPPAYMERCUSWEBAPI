using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ISurePay
{
    public class ISuarePayValidationInput:BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
    }
    public class ISuarePayValidationOutput : BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }
    }
}
