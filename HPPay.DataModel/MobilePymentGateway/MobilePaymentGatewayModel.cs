using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.MobilePaymentGatewayModel
{
    public class MobilePaymentGatewayModelInPut : BaseClass
    {        

        [JsonPropertyName("accessCode")]
        [DataMember]
        public string accessCode { get; set; }

        [JsonPropertyName("workingKey")]
        [DataMember]
        public string workingKey { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }
        

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

         
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("SourceId")]        
        [DataMember]
        public string SourceId { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public string Formfactor { get; set; }

        [JsonPropertyName("TransactionFor")]
        [DataMember]
        public string TransactionFor { get; set; }

        [JsonPropertyName("Currency")]
        [DataMember]
        public string Currency { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonPropertyName("Request")]
        [DataMember]
        public string Request { get; set; }
                

    }
    public class GetSecureToken 
    {
        [JsonPropertyName("requestId")]
        [DataMember]
        public string requestId { get; set; }

        [JsonPropertyName("accessCode")]
        [DataMember]
        public string accessCode { get; set; }

        [JsonPropertyName("requestHash")]
        [DataMember]
        public string requestHash { get; set; }

        [JsonPropertyName("secureToken")]
        [DataMember]
        public string secureToken { get; set; }
        


    }
        public class MobilePaymentGatewayModelOutPut :BaseClassOutput
    {

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("orderId")]
        [DataMember]
        public string orderId { get; set; }

        [JsonProperty("RequestHash")]
        [DataMember]
        public string RequestHash { get; set; }

        [JsonProperty("ResponseUrl")]
        [DataMember]
        public string ResponseUrl { get; set; }

        [JsonProperty("Id")]
        [DataMember]
        public string Id { get; set; }

    }
     
}
