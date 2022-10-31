using Newtonsoft.Json; 
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.PayEnrollmentFee
{
    public class InitiateEnrollmentFeeByHDFCModelInput : BaseClass
    {
        
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        
        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("EncResponseUrl")]
        [DataMember]
        public string EncResponseUrl { get; set; }

        [Required]
        [JsonPropertyName("FormNo")]
        [DataMember]
        public string FormNo { get; set; }
         
        [JsonPropertyName("NoOfCard")]
        [DataMember]
        public string NoOfCard { get; set; }
         

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }
    public class InitiateEnrollmentFeeByHDFCModelOutPut : BaseClassOutput
    {
        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }        

        [JsonProperty("Response")]
        [DataMember]
        public ApiRequestResponse Response { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("email")]
        [DataMember]
        public string email { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("NoOfCards")]
        [DataMember]
        public string NoOfCards { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

    } 

    public class ApiRequestResponse:BaseClass
    {
        public string BankName { get; set; }
        public string TransactionId { get; set; }
        public string request { get; set; }
        public object response { get; set; }
        public string apiurl { get; set; } 
        public string request_Hash { get; set; }
        public string accessCode { get; set; }
        public string CustomerId { get; set; }
        public string ControlCardNo { get; set; }
        public decimal Amount { get; set; }

        public string email { get; set; }
        public string Mobile { get; set; }

    }
    public class RechargeLoginResponse
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    } 
}
