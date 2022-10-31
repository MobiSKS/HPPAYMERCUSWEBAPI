using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{

    public class TransactionContrlCardPinChangeInput : BaseClassTerminal
    {

        

        [Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }


        [Required]
        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [Required]
        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [Required]
        [JsonPropertyName("CCNPinold")]
        [DataMember]
        public string CCNPinold { get; set; }

        [Required]
        [JsonPropertyName("CCNPinnew")]
        [DataMember]
        public string CCNPinnew { get; set; }

        
        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }
    }

    public class TransactionContrlCardPinChangeOutput : BaseClassOutput
    {

    }
}
