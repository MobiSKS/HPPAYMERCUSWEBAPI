using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.M2PExternal
{
    internal class M2PExtenalTransactionReversalModel
    {
    }

    public class M2PTransactionReversalModelInput : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }

        [JsonPropertyName("BankID")]
        [DataMember]
        [Required]
        public int BankID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        [Required]
        public string CardNo { get; set; }

        [JsonPropertyName("TxnRefId")]
        [DataMember]
        [Required]
        public string TxnRefId { get; set; }

        public string TxnNo { get; set; }

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


        [Required]
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

        [Required]
        [JsonPropertyName("DCSTokenNo")]
        [DataMember]
        public string DCSTokenNo { get; set; }

        [Required]
        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }
    }

    public class M2PTransactionReversalModelOutput : BaseClassOutput
    {
        public string MsgType { get; set; }
        //public string ErrorReason { get; set; }
        public bool Result { get; set; }
        public string DetailMessage { get; set; }
        public string ShortMessage { get; set; }
        public string ErrorCode { get; set; }
    }

    public class M2PTransactionReversalRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefrenceNumber { get; set; }
    }

    public class M2PTransactionReversalResponse
    {
        public bool result { get; set; }
        public M2PResponseException exception { get; set; }
    }


    public class CheckM2PInvoiceIdBatchIdExistInput
    {

        public string Invoiceid { get; set; }
        public Int64 Batchid { get; set; }
        public int RecordType { get; set; }
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }

        public string UserId { get; set; }
        public string TransTypeId { get; set; }



    }
    public class CheckM2PInvoiceIdBatchIdExistOutput : BaseClassOutput
    {

    }
}
