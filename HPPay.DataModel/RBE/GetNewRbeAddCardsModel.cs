using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetNewRbeAddCardsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }

    public class GetNewRbeAddCardsModelOutput
    {
        [JsonProperty("EnrollDate")]
        [DataMember]
        public string EnrollDate { get; set; }

        [JsonProperty("CustomerFormNumber")]
        [DataMember]
        public string CustomerFormNumber { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

       

        [JsonProperty("CustomerMobile")]
        [DataMember]
        public string CustomerMobile { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("NoOfCards")]
        [DataMember]
        public string NoOfCards { get; set; }

        [JsonProperty("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
}
