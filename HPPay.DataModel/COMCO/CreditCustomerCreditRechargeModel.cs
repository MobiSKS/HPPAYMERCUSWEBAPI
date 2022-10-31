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
    public class CreditCustomerCreditRechargeModelInput: BaseClass
    {
        [Required]
        [JsonPropertyName("PaymentMode")]
        [DataMember]
        public int PaymentMode { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("ChequeDDBDSReferenceNumber")]
        [DataMember]
        public string ChequeDDBDSReferenceNumber { get; set; }

        [Required]
        [JsonPropertyName("ChequeDDBDSReferenceDate")]
        [DataMember]
        public string ChequeDDBDSReferenceDate { get; set; }

        [Required]
        [JsonPropertyName("ClubbingCategory")]
        [DataMember]
        public int ClubbingCategory { get; set; }

        [Required]
        [JsonPropertyName("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [Required]
        [JsonPropertyName("BranchName")]
        [DataMember]
        public string BranchName { get; set; }

        [Required]
        [JsonPropertyName("DepositBank")]
        [DataMember]
        public string DepositBank { get; set; }


        [Required]
        [JsonPropertyName("RealizationDate")]
        [DataMember]
        public string RealizationDate { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        

    }
    public class CreditCustomerCreditRechargeModelOutput : BaseClassOutput
    {
    }
}
