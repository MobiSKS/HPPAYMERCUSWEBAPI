using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCPG
{
    public class GetHDFCPGResponseModelInput : BaseClass
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

    public class GetHDFCPGResponseModelOutput : BaseClassOutput
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

    public class GetHDFCPGEncResponseModelInput : BaseClass
    {
        [JsonPropertyName("EncResponse")]
        [DataMember]
        public string EncResponse { get; set; }
    }
    public class GetHDFCPGEncResponseModelOutput : BaseClassOutput
    {
        [JsonProperty("Response")]
        [DataMember]
        public string Response { get; set; }
    }

    public class GetHDFCPaymentStatusModelInput : BaseClass
    {
        [JsonPropertyName("orderId")]
        [DataMember]
        public string orderId { get; set; }

         
    }

    public class GetHDFCPaymentStatusModelOutput :BaseClassOutput
    {
        [JsonProperty("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
         
    }

}
