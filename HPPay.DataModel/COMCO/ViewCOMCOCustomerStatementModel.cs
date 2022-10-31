using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{

    public class ViewCOMCOCustomerStatementModelInput : BaseClass
    {
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string @FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string @ToDate { get; set; }
    }

    public class ViewCOMCOCustomerStatementModelOutput
    {
        [JsonProperty("CreditMerchantCustomerDetails")]
        public List<CreditMerchantCustomerDetails> CreditMerchantCustomerDetails { get; set; }

        [JsonProperty("TransactionStatement")]
        public List<TransactionStatement> TransactionStatement { get; set; }
    }

    public class CreditMerchantCustomerDetails 
    {
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("MerchantAddress")]
        [DataMember]
        public string MerchantAddress { get; set; }

        [JsonProperty("Period")]
        [DataMember]
        public string Period { get; set; }

    }

    public class TransactionStatement
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("BatchId")]
        [DataMember]
        public int BatchId { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonProperty("InvoiceAmount")]
        [DataMember]
        public decimal InvoiceAmount { get; set; }

        [JsonProperty("Voucher")]
        [DataMember]
        public string Voucher { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

        [JsonProperty("Finance")]
        [DataMember]
        public string Finance { get; set; }
        [JsonProperty("Currency")]
        [DataMember]
        public string Currency { get; set; }

    }
}
