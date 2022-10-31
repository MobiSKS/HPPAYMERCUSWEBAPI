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
    public class PCCCMSBalanceInfoModelInput : BaseClass
    {

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }
    public class PCCCMSBalanceInfoModelOutPut : BaseClassOutput
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
        public string OpeningBalance { get; set; }

        [JsonProperty("PostingMethod")]
        [DataMember]
        public string PostingMethod { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonProperty("ClosingBalance")]
        [DataMember]
        public string ClosingBalance { get; set; }
    }
}
