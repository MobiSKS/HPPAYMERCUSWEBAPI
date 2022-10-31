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
    public class CustomerBalanceInfoDrivestarsModelInput
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerBalanceInfoDrivestarsModelOutput : BaseClassOutput
    {

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

        [JsonProperty("Drivestars")]
        [DataMember]
        public string Drivestars { get; set; }

        [JsonProperty("ClosingBalance")]
        [DataMember]
        public string ClosingBalance { get; set; }

    }
}
