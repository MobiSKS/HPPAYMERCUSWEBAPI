using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class TransferAmountCCMSToCardModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("CCMSToCardTransfer")]
        [DataMember]
        public List<CCMSToCardTransfer> CCMSToCardTransfer { get; set; }

    }
    public class CCMSToCardTransfer
    {
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
        [Required]
        [JsonPropertyName("TransferAmount")]
        [DataMember]
        public decimal TransferAmount { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class TransferAmountCCMSToCardModelOutput:BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("RecordNumber")]
        [DataMember]
        public string RecordNumber { get; set; }
        

    }
}
