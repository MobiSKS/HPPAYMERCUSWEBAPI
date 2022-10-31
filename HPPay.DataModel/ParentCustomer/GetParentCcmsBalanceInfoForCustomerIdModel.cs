using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCcmsBalanceInfoForCustomerIdModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetParentCcmsBalanceInfoForCustomerIdModelOutput
    {
        [JsonProperty("Mode")]
        [DataMember]
        public string Mode { get; set; }

        [JsonProperty("Description")]
        [DataMember]
        public string Description { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("OpeningBalance")]
        [DataMember]
        public decimal OpeningBalance { get; set; }

        [JsonProperty("PostingMethod")]
        [DataMember]
        public string PostingMethod { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("ClosingBalance")]
        [DataMember]
        public decimal ClosingBalance { get; set; }

    }
}
