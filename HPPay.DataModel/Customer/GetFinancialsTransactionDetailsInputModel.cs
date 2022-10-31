using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public  class GetFinancialsTransactionDetailsInputModel:BaseClass
    {
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }


    public class GetFinancialsTransactionDetailsOutPutModel : BaseClassOutput
    {
        [JsonProperty("BatchId")]
        [DataMember]
        public int BatchId { get; set; }

        [JsonProperty("ROCNo")]
        [DataMember]
        public int InvoiceNo { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }



        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }


        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }


        [JsonProperty("Price")]
        [DataMember]
        public string Price { get; set; }

        [JsonProperty("Volume_ltr_")]
        [DataMember]
        public string Volume_ltr_ { get; set; }


        [JsonProperty("Currency")]
        [DataMember]
        public string Currency { get; set; }


        [JsonProperty("ServiceCharge")]
        [DataMember]
        public string ServiceCharge { get; set; }


        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonProperty("DriveStars")]
        [DataMember]
        public decimal DriveStars { get; set; }

        [JsonProperty("[Voided by ROC]")]
        [DataMember]
        public string OdometerReading { get; set; }


        [JsonProperty("[Voided ROC]")]
        [DataMember]
        public decimal PerviousDriveStars { get; set; }


        [JsonProperty("[FSM Name]")]
        [DataMember]
        public string Bankname { get; set; }



        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [JsonProperty("BatchSettlementStatus")]
        [DataMember]
        public string BatchSettlementStatus { get; set; }



    }
}
