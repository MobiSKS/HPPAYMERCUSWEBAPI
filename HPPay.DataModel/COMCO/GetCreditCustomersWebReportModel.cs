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
    public class GetCreditCustomersWebReportModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }
    public class GetCreditCustomersWebReportModelOutput 
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }
        [JsonProperty("Transtype")]
        [DataMember]
        public string Transtype { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }


        [JsonProperty("RSP")]
        [DataMember]
        public decimal RSP { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

        [JsonProperty("FinanceCharge")]
        [DataMember]
        public string FinanceCharge { get; set; }


    }
}
