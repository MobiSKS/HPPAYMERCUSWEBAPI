using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFCAPI
{
    public class STFCGetAllTransactionsModelInput:STFCAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class STFCGetAllTransactionsModelOutput
    {

        [JsonProperty("lstTransactionDetailInfo")]
        [DataMember]
        public List<TransactionDetailInfo> lstTransactionDetailInfo { get; set; }


        [JsonProperty("TransactionDetail")]
        [DataMember]
        public List<TransactionDetails> TransactionDetail { get; set; }
    }

    public class STFCGetAllTransactionsModelFInalOutput
    {

        [JsonProperty("customerId")]
        [DataMember]
        public string customerId { get; set; }

        [JsonProperty("startDate")]
        [DataMember]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        [DataMember]
        public string endDate { get; set; }

        [JsonProperty("txnCount")]
        [DataMember]
        public decimal txnCount { get; set; }



        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("lstTransactionDetailInfo")]
        [DataMember]
        public List<TransactionDetailInfo> lstTransactionDetailInfo { get; set; }

    }
    public class TransactionDetails : STFCAPIBaseClassOutput
    {
        [JsonProperty("customerId")]
        [DataMember]
        public string customerId { get; set; }

        [JsonProperty("startDate")]
        [DataMember]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        [DataMember]
        public string endDate { get; set; }

        [JsonProperty("txnCount")]
        [DataMember]
        public decimal txnCount { get; set; }

    }
    public class TransactionDetailInfo
    {
        [JsonProperty("terminalCode")]
        [DataMember]
        public string terminalCode { get; set; }

        [JsonProperty("customerCode")]
        [DataMember]
        public string customerCode { get; set; }

        [JsonProperty("merchantName")]
        [DataMember]
        public string merchantName { get; set; }

        [JsonProperty("merchantLocation")]
        [DataMember]
        public string merchantLocation { get; set; }

        [JsonProperty("merchantState")]
        [DataMember]
        public string merchantState { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("vehicleNo")]
        [DataMember]
        public string vehicleNo { get; set; }

        [JsonProperty("tranDate")]
        [DataMember]
        public string tranDate { get; set; }

        [JsonProperty("serviceName")]
        [DataMember]
        public string serviceName { get; set; }

        [JsonProperty("amount")]
        [DataMember]
        public decimal amount { get; set; }

        [JsonProperty("balance")]
        [DataMember]
        public string balance { get; set; }

        [JsonProperty("driveStars")]
        [DataMember]
        public string driveStars { get; set; }


        [JsonProperty("voidRoc")]
        [DataMember]
        public string voidRoc { get; set; }

        [JsonProperty("tranType")]
        [DataMember]
        public string tranType { get; set; }


        [JsonProperty("batchID")]
        [DataMember]
        public string batchID { get; set; }


        [JsonProperty("rawTransactionId")]
        [DataMember]
        public string rawTransactionId { get; set; }


        [JsonProperty("roc")]
        [DataMember]
        public int roc { get; set; }


        [JsonProperty("currency")]
        [DataMember]
        public string currency { get; set; }


        [JsonProperty("batchIDAndROC")]
        [DataMember]
        public string batchIDAndROC { get; set; }


        [JsonProperty("odometerReading")]
        [DataMember]
        public string odometerReading { get; set; }


        [JsonProperty("serviceCharge")]
        [DataMember]
        public string serviceCharge { get; set; }


        [JsonProperty("productRSPVolume")]
        [DataMember]
        public string productRSPVolume { get; set; }


        [JsonProperty("rsp")]
        [DataMember]
        public decimal rsp { get; set; }


        [JsonProperty("volume")]
        [DataMember]
        public string volume { get; set; }


        [JsonProperty("rewardType")]
        [DataMember]
        public string rewardType { get; set; }

        [JsonProperty("status")]
        [DataMember]
        public string status { get; set; }
    }

}
