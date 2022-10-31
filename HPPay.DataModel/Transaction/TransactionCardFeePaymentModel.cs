using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Transaction
{
    public class TransactionCardFeePaymentModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [JsonPropertyName("Formno")]
        [DataMember]
        public string Formno { get; set; }


        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }

        [JsonPropertyName("Noofcards")]
        [DataMember]
        public Int32 Noofcards { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        public decimal Invoiceamount { get; set; }


        [JsonPropertyName("Transtype")]
        [DataMember]
        public string Transtype { get; set; }


        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }


        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }

        [JsonPropertyName("Sourceid")]
        [DataMember]
        public Int32 Sourceid { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }


        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }

    }

    public class TransactionCardFeePaymentModelOutput : BaseClassOutput
    {
        [JsonProperty("RefNo")]
        [DataMember]
        public string RefNo { get; set; }
    }
}
