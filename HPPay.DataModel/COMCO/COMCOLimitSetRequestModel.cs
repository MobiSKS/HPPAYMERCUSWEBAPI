using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class COMCOLimitSetRequestModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
        [JsonPropertyName("LimitSetMode")]
        [DataMember]
        public int LimitSetMode { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

         
         [JsonPropertyName("NoofCheques")]
         [DataMember]
         public int NoofCheques { get; set; }

        [Required]
        [JsonPropertyName("CautionAmount")]
        [DataMember]
        public decimal CautionAmount { get; set; }

        [Required]
        [JsonPropertyName("ScannedReferenceDocument")]
        [DataMember]
        public IFormFile ScannedReferenceDocument { get; set; }

        [Required]
        [JsonPropertyName("InvoiceIntervalId")]
        [DataMember]
        public int InvoiceIntervalId { get; set; }

        [Required]
        [JsonPropertyName("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }

        [Required]
        [JsonPropertyName("FinanceCharges")]
        [DataMember]
        public decimal FinanceCharges { get; set; }

        [Required]
        [JsonPropertyName("ServicesCharges")]
        [DataMember]
        public decimal ServicesCharges { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("ChequeBDSCRNumber")]
        [DataMember]
        public List<string> ChequeBDSCRNumber { get; set; }


        [JsonPropertyName("ChequeBDSCRDate")]
        [DataMember]
        public List<string> ChequeBDSCRDate { get; set; }

        //[JsonPropertyName("TypeInsertChequeDetails")]
        //[DataMember]
        //public List<TypeInsertChequeDetails> TypeInsertChequeDetails { get; set; }

    }

    //public class TypeInsertChequeDetails 
    //{
      
       

    //}
    public class COMCOLimitSetRequestModelOutput:BaseClassOutput
    {
    }
}
