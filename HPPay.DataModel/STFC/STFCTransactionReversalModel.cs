using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFC
{
    public class STFCTransactionReversalModelInput : BaseClass
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

    public class STFCTransactionReversalModelOutput : BaseClassOutput
    {
        public string MsgType { get; set; }
        public string ErrorReason { get; set; }
    }

    public class STFCTransactionReversalRequest
    {
    }

    //public class STFCTransactionReversalResponse
    //{
    //    public string DTPRefNo { get; set; }
    //}


    public class CheckSTFCInvoiceIdBatchIdExistInput
    {

        public string Invoiceid { get; set; }
        public Int64 Batchid { get; set; }
        public int RecordType { get; set; }
        public string MerchantID { get; set; }
        public string TerminalID { get; set; }

        public string UserId { get; set; }
        public string TransTypeId { get; set; }



    }
    public class CheckSTFCInvoiceIdBatchIdExistOutput : BaseClassOutput
    {

    }

    public class CheckCardLimitValidationforAPIInput
    {
        public string CardNo { get; set; }
        public string Mobileno { get; set; }
        public DateTime Invoicedate { get; set; }
        public decimal Invoiceamount { get; set; }
        public int Sourceid { get; set; }
        public int Formfactor { get; set; }

        public string Pin { get; set; }
        public string Userid { get; set; }

    }

    public class CheckCardLimitValidationforAPIOutput : BaseClassOutput
    {
        public string CardNumber { get; set; }
    }

}
