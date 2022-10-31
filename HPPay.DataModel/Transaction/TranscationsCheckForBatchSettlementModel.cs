using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{
    public class TranscationsCheckForBatchSettlementModelInput : BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [Required]
        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [Required]
        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }


        [JsonPropertyName("ObjTranscationsForBatchSettlement")]
        [DataMember]
        public List<TranscationsForBatchSettlement> ObjTranscationsForBatchSettlement { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class TranscationsForBatchSettlement
    {
        [Required]
        [JsonPropertyName("Trantype")]
        [DataMember]
        public string Trantype { get; set; }

        [Required]
        [JsonPropertyName("Transcount")]
        [DataMember]
        public Int32 Transcount { get; set; }


        [Required]
        [JsonPropertyName("Totalamount")]
        [DataMember]
        public decimal Totalamount { get; set; }
    }

    public class TranscationsCheckForBatchSettlementModelOutput : BaseClassOutput
    {

    }



    public class TranscationsCheckForBatchUploadModelInput : BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [Required]
        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [Required]
        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }


        [JsonPropertyName("ObjTranscationsForBatchUpload")]
        [DataMember]
        public List<TranscationsForBatchUpload> ObjTranscationsForBatchUpload { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class TranscationsForBatchUpload
    {
        [Required]
        [JsonPropertyName("Trantype")]
        [DataMember]
        public string Trantype { get; set; }

        [Required]
        [JsonPropertyName("Transcount")]
        [DataMember]
        public Int32 Transcount { get; set; }


        [Required]
        [JsonPropertyName("Totalamount")]
        [DataMember]
        public decimal Totalamount { get; set; }
    }

    public class TranscationsCheckForBatchUploadModelOutput : BaseClassOutput
    {

    }
}
