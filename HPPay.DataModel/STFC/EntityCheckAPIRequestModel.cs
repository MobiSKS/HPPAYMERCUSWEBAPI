using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFC
{

    public class CardInfo
    {
        public string Info { get; set; }
    }

    public class CreditLimitAuthorizationAPIOutput : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("AvailableLimit")]
        [DataMember]
        public string AvailableLimit { get; set; }

        [JsonProperty("STFCCustomerID")]
        [DataMember]
        public string STFCCustomerID { get; set; }

        [JsonProperty("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonProperty("Batchid")]
        [DataMember]
        public int Batchid { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; } = "-";
    }
   
    public class EntityCheckAPIRequestModelInput:BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        [Required]
        public string CardNo  { get; set; }       

        [JsonPropertyName("Amount")]
        [DataMember]
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [Required]
        [JsonPropertyName("Batchid")]
        [DataMember]
        public long Batchid { get; set; }

        [Required]
        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }

        [Required]
        [JsonPropertyName("Productid")]
        [DataMember]
        public int Productid { get; set; }


        //[Required]
        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }

        [Required]
        [JsonPropertyName("TransType")]
        [DataMember]
        public string TransType { get; set; }

        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }

        //[Required]
        [JsonPropertyName("DCSTokenNo")]
        [DataMember]
        public string DCSTokenNo { get; set; }

        [Required]
        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }

    }

    public class STFCConfirmPaymentResponse : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("AvailableLimit")]
        [DataMember]
        public string AvailableLimit { get; set; }

        [JsonProperty("STFCCustomerID")]
        [DataMember]
        public string STFCCustomerID { get; set; }

        [JsonProperty("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [JsonProperty("CardNoOutput")]
        [DataMember]
        public string CardNoOutput { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonProperty("Batchid")]
        [DataMember]
        public long Batchid { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; } = "-";

        [JsonProperty("RefNo")]
        [DataMember]
        public string RefNo { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; } = "-";
    }
    public class CreditLimitAuthorizationModelOutput : BaseClassOutput
    {
        public string MsgType { get; set; }
        public string ErrorReason { get; set; }

        //public string ResCode { get; set; }
        //public string ResMsg { get; set; }
        public string AvailableLimit { get; set; }
        public string STFCCustomerID { get; set; }
        public string DTPCustomerID { get; set; }
        public string CardNumber { get; set; }
        public string TxnId { get; set; }
        public string RSP { get; set; }
        public string Volume { get; set; }
        public string RefNo { get; set; }
    }

    public class EntityCheckAPIRequest
    {
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }
        public string CardNo { get; set; }
        public string DTPCustomerId { get; set; }
        public string CreatedBy { get; set; }
        public int RequestID { get; set; }

    }
    public class EntityCheckAPIResponse
    {
        public string MsgType { get; set; }
        public string ErrorReason { get; set; }
        public string AvailableLimit { get; set; }
    }



    public class GetStfcCustomerIdByCardOutput : BaseClassOutput
    {
        public string CustomerId { get; set; }
    }

        public class GetCustomerIdByCardForExternalAPIOutput : BaseClassOutput
    {
        public string CustomerId { get; set; }
        public string SourceName { get; set; }
        public string SourceCustomerId { get; set; }
    }

    
}
