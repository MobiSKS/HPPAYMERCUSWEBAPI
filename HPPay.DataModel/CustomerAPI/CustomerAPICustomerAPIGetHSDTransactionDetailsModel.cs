using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPICustomerAPIGetHSDTransactionDetailsModelInput
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public int intUID { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public List<JsonHSDTranDetail> jsonHSDTranDetails { get; set; }
    }
    public class JsonHSDTranDetail
    {
        public int Slno { get; set; }
        public string SAMId { get; set; }
        public string MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string CustomerID { get; set; }
        public string CardPAN { get; set; }
        public string VehicleNo { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string Product { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public double RSP { get; set; }
        public double Quantity { get; set; }
        public string Balance { get; set; }
        public string XtraPoints { get; set; }
        public string TransactionId { get; set; }
        public string OdoMeter { get; set; }
        public string SettlementDate { get; set; }
        public string Status { get; set; }
        public string InvoiceDetailsId { get; set; }
    }
    public class CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput
    {
        [JsonProperty("responseMessageCode")]
        [DataMember]
        public string responseMessageCode { get; set; }
        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }
}
