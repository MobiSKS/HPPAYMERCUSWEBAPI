using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.M2PExternal
{
    public class M2PEntityCheckAPIRequestModelInput:BaseClass
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
        public string CardNo { get; set; }

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
        public int Batchid { get; set; }

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


    public class M2PConfirmPaymentResponse : BaseClassOutput
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

        [JsonProperty("M2PCustomerID")]
        [DataMember]
        public string M2PCustomerID { get; set; }

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


    public class M2PCreditLimitAuthorizationModelOutput : BaseClassOutput
    {
        public string MsgType { get; set; }
        //public string ErrorReason { get; set; }

        public bool Result { get; set; }
        public string DetailMessage { get; set; }
        public string ShortMessage { get; set; }
        public string ErrorCode { get; set; }
        public string AvailableLimit { get; set; }
        public string DTPCustomerID { get; set; }
        public string M2PCustomerID { get; set; }
        public string CardNumber { get; set; }
        public string RSP { get; set; }
        public string Volume { get; set; }
        public string RefNo { get; set; }
    }

    public class M2PEntityCheckAPIRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public string M2PCustomerId { get; set; }
        public string PartnerCustomerId { get; set; }

    }

    public class M2PCreaditAuthAPIRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public string M2PCustomerId { get; set; }
        public string PartnerCustomerId { get; set; }
        public string TransactionAmount { get; set; }
        public string TransactionDate { get; set; }
        public string RefrenceNumber { get; set; }

    }

    public class M2PCreaditAuthAPIResponse
    {
        public bool result { get; set; }
        public M2PResponseException exception { get; set; }
        public string AvailableLimit { get; set; }
    }
    public class M2PEntityCheckAPIResponse
    {
        //public string MsgType { get; set; }
        //public string ErrorReason { get; set; }
        public bool result { get; set; }
        public M2PResponseException exception { get; set; }
        public string AvailableLimit { get; set; }
    }
    public class M2PResponseException
    {
        public string detailMessage { get; set; }
        public string shortMessage { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }


    }

    public class GetM2PCustomerIdByCardOutput : BaseClassOutput
    {
        public string CustomerId { get; set; }
    }
}
