using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetViewMerchantEarningbreakupModelInput:BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TxnType")]
        [DataMember]
        public string TxnType { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }


    public class MerchantGetViewMerchantEarningbreakupModelOutput : BaseClassOutput
    {
        //[JsonProperty("SrNo")]
        //[DataMember]
        //public string SrNo { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("EarningAmount")]
        [DataMember]
        public decimal EarningAmount { get; set; }

        [JsonProperty("SaleAmount")]
        [DataMember]
        public decimal SaleAmount { get; set; }


        [JsonProperty("Slab")]
        [DataMember]
        public string Slab { get; set; }


        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }


        [JsonProperty("TransactionSource")]
        [DataMember]
        public string TransactionSource { get; set; }


        [JsonProperty("Transactiondate")]
        [DataMember]
        public string Transactiondate { get; set; }


    }
}
