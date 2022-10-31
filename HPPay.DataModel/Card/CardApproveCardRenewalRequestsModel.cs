using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CardApproveCardRenewalRequestsModelInput : BaseClass
    {

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }
    public class CardApproveCardRenewalRequestsModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        //[JsonProperty("StatusFlag")]
        //[DataMember]
        //public int StatusFlag { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }


        //[JsonProperty("CreatedTime")]
        //[DataMember]
        //public string CreatedTime { get; set; }

        //[JsonProperty("ModifiedBy")]
        //[DataMember]
        //public string ModifiedBy { get; set; }

        //[JsonProperty("ModifiedTime")]
        //[DataMember]
        //public string ModifiedTime { get; set; }

        //[JsonProperty("RenewalStatus")]
        //[DataMember]
        //public int RenewalStatus { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }


}
