using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{
    public class TransactionUnblockCardPinCheckStatusThroughCCNModelInput: BaseClassTerminal
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
        [JsonPropertyName("CCNPin")]
        [DataMember]
        public string CCNPin { get; set; }

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public Int32 Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }
    }

    public class TransactionUnblockCardPinCheckStatusThroughCCNModelOutput : BaseClassOutput
    {

    }
}
