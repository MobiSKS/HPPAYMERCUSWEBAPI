using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetTransactionsSummaryModelInput : BaseClass
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

    public class CustomerGetTransactionsSummaryModelOutput
    {
        [JsonProperty("GetTransactionsSaleSummary")]
        public List<CustomerGetTransactionsSaleSummaryModelOutput> GetTransactionsSaleSummary { get; set; }

        [JsonProperty("GetTransactionsDetailSummary")]
        public List<CustomerGetTransactionsDetailSummaryModelOutput> GetTransactionsDetailSummary { get; set; }
    }

    public class CustomerGetTransactionsSaleSummaryModelOutput
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

    public class CustomerGetTransactionsDetailSummaryModelOutput
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

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("TxnID")]
        [DataMember]
        public string TxnID { get; set; }

        [JsonProperty("BatchId")]
        [DataMember]
        public string BatchId { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }

        [JsonProperty("RetailOutletLocation")]
        [DataMember]
        public string RetailOutletLocation { get; set; }


        [JsonProperty("RetailOutletAddress")]
        [DataMember]
        public string RetailOutletAddress { get; set; }


        [JsonProperty("RetailOutletDistrict")]
        [DataMember]
        public string RetailOutletDistrict { get; set; }


        [JsonProperty("RetailOutletState")]
        [DataMember]
        public string RetailOutletState { get; set; }

        [JsonProperty("PancardNumber")]
        [DataMember]
        public string PancardNumber { get; set; }

        [JsonProperty("CreditDebit")]
        [DataMember]
        public string CreditDebit { get; set; }


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }


        [JsonProperty("CommunicationCity")]
        [DataMember]
        public string CommunicationCity { get; set; }


        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }


        [JsonProperty("CommunicationState")]
        [DataMember]
        public string CommunicationState { get; set; }


        [JsonProperty("CommunicationDistrict")]
        [DataMember]
        public string CommunicationDistrict { get; set; }

        [JsonProperty("CommunicationPinCode")]
        [DataMember]
        public string CommunicationPinCode { get; set; }

        [JsonProperty("UTRNo")]
        [DataMember]
        public string UTRNo { get; set; }


    }
}
