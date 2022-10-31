using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public  class InsertCreditPouchReferralDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [Required]
        [JsonPropertyName("ContactPerson")]
        [DataMember]
        public string ContactPerson { get; set; }

        [JsonPropertyName("City")]
        [DataMember]
        public string City { get; set; }
         
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }


        [JsonPropertyName("PinCode")]
        [DataMember]
        public int PinCode { get; set; }

        [Required]
        [JsonPropertyName("Mobile")]
        [DataMember]
        public string Mobile { get; set; }
         
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }
         
        [JsonPropertyName("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }
         
        [JsonPropertyName("FuleReqPerMonth")]
        [DataMember]
        public decimal FuleReqPerMonth { get; set; }
         
        [JsonPropertyName("Address")]
        [DataMember]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType     { get; set; }


        [JsonPropertyName("DetailsSharedBy")]
        [DataMember]
        public string DetailsSharedBy { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }


        [JsonPropertyName("RequestType")]
        [DataMember]
        public string RequestType { get; set; }

        [JsonPropertyName("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

        

    }
    public class InsertCreditPouchReferralDetailsModelOutPut : BaseClassOutput
    {
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

    }

}
