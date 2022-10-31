using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentTransactionsSummaryModelInput : BaseClass
    { 
        [JsonPropertyName("ChildCustomerID")]
        [DataMember]
        public string ChildCustomerID { get; set; }

        [JsonPropertyName("ParentCustomerID")]
        [DataMember]
        public string ParentCustomerID { get; set; }


    }

    public class GetParentTransactionsSummaryModelOutput
    {        
        [JsonProperty("ChildCustomerName")]
        [DataMember]
        public string ChildCustomerName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("ChildId")]
        [DataMember]
        public string ChildId { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        
    }
    public class ChildCustomerTransactionsDetails
    {
        [JsonPropertyName("Id")]
        [DataMember]
        public int Id { get; set; }

        [JsonPropertyName("ChildCustomerID")]
        [DataMember]
        public string ChildCustomerID { get; set; }

    }

        public class GetParentTransactionsSummaryDetailsModelInput : BaseClassOutput
    {
        [JsonPropertyName("ObjChildCustomerIdDtl")]
        [DataMember]
        public List<ChildCustomerTransactionsDetails> ObjChildCustomerIdDtl { get; set; }

        [JsonPropertyName("ParentCustomerID")]
        [DataMember]
        public string ParentCustomerID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        

    }
    public class GetParentTransactionsSummaryDetailsModelOutput : BaseClass
    {
        [JsonProperty("GetParentTransactionsSaleDetails")]
        public List<GetParentTransactionsSaleSummary> GetParentTransactionsSaleDetails { get; set; }

        [JsonProperty("GetParentTransactionsDetailSummary")]
        public List<GetParentCustomerTransactionsDetail> GetParentTransactionsDetailSummary { get; set; }

        [JsonProperty("GetChildTransactionsDetailSummary")]
        public List<GetParentCustomerTransactionsDetail> GetChildTransactionsDetailSummary { get; set; }
    }

    public class GetParentCustomerTransactionsDetail
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("BatchIdandROC")]
        [DataMember]
        public string BatchIdandROC { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("Merchant")]
        [DataMember]
        public string Merchant { get; set; }

        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }

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
        public string Amount { get; set; }

        [JsonProperty("Discount")]
        [DataMember]
        public string Discount { get; set; }

        [JsonProperty("OdometerReading")]
        [DataMember]
        public string OdometerReading { get; set; }

        [JsonProperty("TrStatus")]
        [DataMember]
        public string TrStatus { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

    }

    public class GetChildByParenModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ParentCustomerID")]
        [DataMember]
        public string ParentCustomerID { get; set; }

    }

    public class GetChildByParenModelOutput : BaseClass
    {
        [JsonPropertyName("ChildCustomerID")]
        [DataMember]
        public string ChildCustomerID { get; set; } 

    }

    public class GetParentTransactionsSaleSummary
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

    public class GetParentCustomerTransactionsDetailSummary
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
