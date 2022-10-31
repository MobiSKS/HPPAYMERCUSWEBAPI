using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ISurePay
{
    public class ISuarePayRequestInput:BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
        
    }
    public class ISuarePayRequestOutput:BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }
    }
}
