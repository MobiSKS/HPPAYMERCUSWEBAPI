using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.PayU
{
    public class PayUPaymentGatewayModelInPut : BaseClass
    {

        [JsonPropertyName("salt")]
        [DataMember]
        public string salt { get; set; }

        [JsonPropertyName("Key")]
        [DataMember]
        public string Key { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("productinfo")]
        [DataMember]
        public string productinfo { get; set; }

        [JsonPropertyName("firstname")]
        [DataMember]
        public string firstname { get; set; }

        [JsonPropertyName("email")]
        [DataMember]
        public string email { get; set; }

        [JsonPropertyName("phone")]
        [DataMember]
        public string phone { get; set; }

        [JsonPropertyName("lastname")]
        [DataMember]
        public string lastname { get; set; }

        [JsonPropertyName("surl")]
        [DataMember]
        public string surl { get; set; }

        [JsonPropertyName("furl")]
        [DataMember]
        public string furl { get; set; }

        [JsonPropertyName("hash")]
        [DataMember]
        public string hash { get; set; }

    }
    public class PayUPaymentGatewayModelOutPut : BaseClassOutput
    {

        [JsonProperty("salt")]
        [DataMember] 
        public string salt { get; set; }

        [JsonProperty("Key")]
        [DataMember]
        public string Key { get; set; }

        [JsonProperty("txnid")]
        [DataMember]
        public string txnid { get; set; }         

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonProperty("productinfo")]
        [DataMember]
        public string productinfo { get; set; }

        [JsonProperty("firstname")]
        [DataMember]
        public string firstname { get; set; }

        [JsonProperty("lastname")]
        [DataMember]
        public string lastname { get; set; }

        [JsonProperty("email")]
        [DataMember]
        public string email { get; set; }

        [JsonProperty("phone")]
        [DataMember]
        public string phone { get; set; }
       

        [JsonProperty("surl")]
        [DataMember]
        public string surl { get; set; }

        [JsonProperty("furl")]
        [DataMember]
        public string furl { get; set; }

        [JsonProperty("hash")]
        [DataMember]
        public string hash { get; set; }

        [JsonProperty("redirectToUrl")]
        [DataMember]
        public string redirectToUrl { get; set; }

        [JsonProperty("payLoad")]
        [DataMember]
        public string payLoad { get; set; }

    }

    public class InitiatePayUPaymentGatewayModelInput : BaseClass
    {
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
         

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }
    public class PayUApiRequestResponse
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
        public string OrderId { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PayUResponse:BaseClass
    {
        public long id { get; set; }
        public string mode { get; set; }
        public string status { get; set; }
        public string unmappedstatus { get; set; }
        public string key { get; set; }
        public string txnid { get; set; }
        public string transaction_fee { get; set; }
        public string amount { get; set; }
        public string cardCategory { get; set; }
        public string discount { get; set; }
        public string addedon { get; set; }
        public string productinfo { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string hash { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string field5 { get; set; }
        public string field7 { get; set; }
        public string payment_source { get; set; }
        public string PG_TYPE { get; set; }
        public string bank_ref_no { get; set; }
        public string ibibo_code { get; set; }
        public string error_code { get; set; }
        public string Error_Message { get; set; }
        public string card_no { get; set; }
        public int is_seamless { get; set; }
        public string surl { get; set; }
        public string furl { get; set; }
        public string responseString { get; set; }
        public string ActionType { get; set; }
        public string TrnsSource { get; set; }

        
    }

    public class GetPayUPGResponseModelInput : BaseClass
    {

        [JsonPropertyName("orderId")]
        [DataMember]
        public string orderId { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("tracking_id")]
        [DataMember]
        public string tracking_id { get; set; }

        [JsonPropertyName("transactionId")]
        [DataMember]
        public string transactionId { get; set; }

        [JsonPropertyName("TrStatus")]
        [DataMember]
        public string TrStatus { get; set; }

        [JsonPropertyName("Response")]
        [DataMember]
        public string Response { get; set; }

        [JsonPropertyName("status_message")]
        [DataMember]
        public string status_message { get; set; }

        [JsonPropertyName("order_status")]
        [DataMember]
        public string order_status { get; set; }

        [JsonPropertyName("bank_ref_no")]
        [DataMember]
        public string bank_ref_no { get; set; }

        [JsonPropertyName("failure_message")]
        [DataMember]
        public string failure_message { get; set; }

        [JsonPropertyName("message")]
        [DataMember]
        public string message { get; set; }

        [JsonPropertyName("payment_mode")]
        [DataMember]
        public string payment_mode { get; set; }

        [JsonPropertyName("trans_date")]
        [DataMember]
        public string trans_date { get; set; }

        [JsonPropertyName("mer_amount")]
        [DataMember]
        public decimal mer_amount { get; set; }

        [JsonPropertyName("failure_messa1ge")]
        [DataMember]
        public string failure_messa1ge { get; set; }

        [JsonPropertyName("redirectTo")]
        [DataMember]
        public string redirectTo { get; set; }
    }

    public class GetPayUPGResponseModelOutput : BaseClassOutput
    {
        [JsonProperty("mobile")]
        [DataMember]
        public string mobile { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("email")]
        [DataMember]
        public string email { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("TransactionTime")]
        [DataMember]
        public string TransactionTime { get; set; }

        [JsonProperty("TransactionApproved")]
        [DataMember]
        public string TransactionApproved { get; set; }

        [JsonProperty("orderId")]
        [DataMember]
        public string orderId { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }

        [JsonProperty("RechargeAmount")]
        [DataMember]
        public string RechargeAmount { get; set; }

        [JsonProperty("UpdatedBalance")]
        [DataMember]
        public string UpdatedBalance { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("PaymentMode")]
        [DataMember]
        public string PaymentMode { get; set; }

    }



}
