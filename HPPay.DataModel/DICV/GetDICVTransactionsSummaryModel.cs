using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{

    public class GetDICVTransactionsSummaryModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class GetDICVTransactionsSummaryModelOutput : BaseClassOutput
    {
        [JsonProperty("GetTransactionsSaleSummary")]
        public List<GetDICVTransactionsSaleSummaryModelOutput> GetTransactionsSaleSummary { get; set; }

        [JsonProperty("GetTransactionsDetailSummary")]
        public List<GetDICVTransactionsDetailSummaryModelOutput> GetTransactionsDetailSummary { get; set; }
    }
    public class GetDICVTransactionsSaleSummaryModelOutput
    {
        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("Sale")]
        [DataMember]
        public decimal Sale { get; set; }

        [JsonProperty("ReloadCcmsCash")]
        [DataMember]
        public decimal ReloadCcmsCash { get; set; }

        [JsonProperty("CcmsRecharge")]
        [DataMember]
        public decimal CcmsRecharge { get; set; }

    }

    public class GetDICVTransactionsDetailSummaryModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }


        [JsonProperty("BatchIdandROC")]
        [DataMember]
        public string BatchIdandROC { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonProperty("TxnType")]
        [DataMember]
        public string TxnType { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("Price")]
        [DataMember]
        public string Price { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

        [JsonProperty("Currency")]
        [DataMember]
        public string Currency { get; set; }

        [JsonProperty("ServiceCharge")]
        [DataMember]
        public string ServiceCharge { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }


        [JsonProperty("Discount")]
        [DataMember]
        public string Discount { get; set; }

        [JsonProperty("OdometerReading")]
        [DataMember]
        public string OdometerReading { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }
    }
}
