using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class GetCardsForLimitUpdateForSingleRechargeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }
    }
    
    public class GetCardsForLimitUpdateForSingleRechargeModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonProperty("LimitId")]
        [DataMember]
        public int LimitId { get; set; }

        [JsonProperty("TypeOfLimit")]
        [DataMember]
        public string TypeOfLimit { get; set; }

        [JsonProperty("CCMSLimitValue")]
        [DataMember]
        public decimal CCMSLimitValue { get; set; }

        [JsonProperty("UpdateStatus")]
        [DataMember]
        public string UpdateStatus { get; set; }
        
    }

     
}
