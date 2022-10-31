using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AmexCreditPouch
{
    public class InitiateAmexRechargeModelInput
    { 
         
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
         

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonPropertyName("month")]
        [DataMember]
        public string month { get; set; }

        [JsonPropertyName("year")]
        [DataMember]
        public string year { get; set; }
        



    }
    public class InitiateAmexRechargeModelOutput : BaseClassOutput
    {
        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
        
        [JsonProperty("Response")]
        [DataMember]
        public string  Response { get; set; }

        [JsonProperty("url")]
        [DataMember]
        public string url { get; set; }

        [JsonProperty("ReqData")]
        [DataMember]
        public string ReqData { get; set; }

        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonProperty("apiOperation")]
        [DataMember]
        public string apiOperation { get; set; }

        [JsonProperty("amount")]
        [DataMember]
        public string amount { get; set; }

        [JsonProperty("currency")]
        [DataMember]
        public string currency { get; set; }

        [JsonProperty("userName")]
        [DataMember]
        public string userName { get; set; }

        [JsonProperty("password")]
        [DataMember]
        public string password { get; set; }
 

    } 
     
     
    

}
