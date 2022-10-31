using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RechargeCCMS
{
    public class InitiateRechargeCCMSModelInput : BaseClass
    {
         
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
         
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }
    public class InitiateRechargeCCMSModelOutPut : BaseClassOutput
    {
        public InitiateRechargeCCMSModelOutPut()
        {
            Response = new CCMSApiRequestResponse();
        }

        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }        

        [JsonProperty("Response")]
        [DataMember]
        public CCMSApiRequestResponse Response { get; set; }
         
    } 

    public class CCMSApiRequestResponse
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
        public string ActionType { get; set; } 
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public int SourceId { get; set; }
        public int Formfactor { get; set; }
        public string UserId { get; set; }
        public int NameOnCard { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public string TrnsSource { get; set; }
    }
    public class CCMSRechargeLoginResponse
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    }
    public class InitiateEnrollmentFeePaymentModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }


}
