using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class InitiateCreditPouchRechargeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
         
         
    }
    public class InitiateCreditPouchRechargeModelOutPut : BaseClassOutput
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

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("FormFactor")]
        [DataMember]
        public string FormFactor { get; set; }

        [JsonProperty("SourceId")]
        [DataMember]
        public string SourceId { get; set; }

        [JsonProperty("CCN")]
        [DataMember]
        public string CCN { get; set; }
        
    } 

    public class ApiRequestResponse
    {
        public string BankName { get; set; }
        public string TransactionId { get; set; }
        public string request { get; set; }
        public object response { get; set; }
        public string apiurl { get; set; }
        public string UserId { get; set; }
        public string request_Hash { get; set; }
        public string accessCode { get; set; }
        public string CustomerId { get; set; }
        public string ControlCardNo { get; set; }
        public decimal Amount { get; set; }
        public string ActionType { get; set; }
        public string TrnsSource { get; set; }
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public int SourceId { get; set; }
        public int Formfactor { get; set; }

    }
    public class CPPGLoginResponse
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    }
    

}
