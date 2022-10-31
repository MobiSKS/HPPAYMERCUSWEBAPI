using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public class BatchUploadModelInput:AGSAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }


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


        [JsonPropertyName("ObjTransactionDetails")]
        [DataMember]
        public List<TransactionDetails> ObjTransactionDetails { get; set; }


        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }

    }

    public class TransactionDetails
    {
        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public Int32 MerchantId { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("ProductName")]
        [DataMember]
        public decimal ProductName { get; set; }


        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public decimal ReferenceNumber { get; set; }

        [Required]
        [JsonPropertyName("TransactionType")]
        [DataMember]
        public decimal TransactionType { get; set; }

        [Required]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public decimal VehicleNumber { get; set; }

        [Required]
        [JsonPropertyName("HashKey")]
        [DataMember]
        public decimal HashKey { get; set; }


    }


    public class UnmatchedTrasnactions
    {
        [Required]  
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }


        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }



        [Required]
        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [Required]
        [JsonPropertyName("Remark")]
        [DataMember]
        public decimal Remark { get; set; }



    }




    public class BatchUploadModelOutput : AGSBaseClassOutput
    {
        [JsonPropertyName("lstUnmatchedTrasnactions")]
        [DataMember]
        public List<UnmatchedTrasnactions> lstUnmatchedTrasnactions { get; set; }


    }
}
