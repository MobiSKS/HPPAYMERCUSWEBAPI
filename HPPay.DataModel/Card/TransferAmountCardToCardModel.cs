using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class TransferAmountCardToCardModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
        [Required]
        [JsonPropertyName("CardToCardTransfer")]
        [DataMember]
        public List<CardToCardTransfer> CardToCardTransfer { get; set; }
    }
    public class CardToCardTransfer
    {

        [JsonPropertyName("FromCardNo")]
        [DataMember]
        public string FromCardNo { get; set; }
        [JsonPropertyName("ToCardNo")]
        [DataMember]
        public string ToCardNo { get; set; }
        [Required]
        [JsonPropertyName("TransferAmount")]
        [DataMember]
        public decimal TransferAmount { get; set; }
        [JsonPropertyName("FromMobileNo")]
        [DataMember]
        public string FromMobileNo { get; set; }
        [JsonPropertyName("ToMobileNo")]
        [DataMember]
        public string ToMobileNo { get; set; }
    }

    public class TransferAmountCardToCardModelOutput : BaseClassOutput
    {
        [JsonProperty("FromCardNo")]
        [DataMember]
        public string FromCardNo { get; set; }

        [JsonProperty("ToCardNo")]
        [DataMember]
        public string ToCardNo { get; set; }

        [JsonProperty("RecordNumber")]
        [DataMember]
        public string RecordNumber { get; set; }
    }
}
