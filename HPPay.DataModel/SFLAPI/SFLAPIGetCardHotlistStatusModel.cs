using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIGetCardHotlistStatusModelInput:SFLAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class SFLAPIGetCardHotlistStatusModelOutput 
    {

        [JsonProperty("cardHotListResponse")]
        [DataMember]
        public List<GetcardHotListResponse> cardHotListResponse { get; set; }

        [JsonProperty("cards")]
        [DataMember]
        public List<Getcards> cards { get; set; }
    }
    public class GetcardHotListResponse
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public class Getcards
    {
        [JsonProperty("applicability")]
        [DataMember]
        public int applicability { get; set; }

        [JsonProperty("dtpCustomerID")]
        [DataMember]
        public string dtpCustomerID { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("referenceNumber")]
        [DataMember]
        public string referenceNumber { get; set; }

        [JsonProperty("customerCardStatusCode")]
        [DataMember]
        public int customerCardStatusCode { get; set; }
        
         [JsonProperty("previousCardStatusCode")]
        [DataMember]
        public int previousCardStatusCode { get; set; }

        [JsonProperty("statusChangeReasonCode")]
        [DataMember]
        public int statusChangeReasonCode { get; set; }

        [JsonProperty("statusChangeAdvisedBy")]
        [DataMember]
        public string statusChangeAdvisedBy { get; set; }

        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }
    }

}
