using Newtonsoft.Json;
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
    public class CustomerCreditandCautionLimitHistoryModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CustomerCreditandCautionLimitHistoryModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public double Amount { get; set; }


        [JsonProperty("FinanceCharges")]
        [DataMember]
        public double FinanceCharges { get; set; }

        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("CautionAmount")]
        [DataMember]
        public double CautionAmount { get; set; }

        [JsonProperty("Mode")]
        [DataMember]
        public string Mode { get; set; }

        [JsonProperty("Status1")]
        [DataMember]
        public string Status1 { get; set; }

        [JsonProperty("InvoiceIntervalType")]
        [DataMember]
        public string InvoiceIntervalType { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }


        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("Approved_RejectedBy")]
        [DataMember]
        public string Approved_RejectedBy { get; set; }


        [JsonProperty("Approved_RejectedDate")]
        [DataMember]
        public string Approved_RejectedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }

    }
}
