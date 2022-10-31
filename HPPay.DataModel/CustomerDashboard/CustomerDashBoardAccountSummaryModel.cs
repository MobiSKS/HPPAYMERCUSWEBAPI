using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerDashboard
{
    public class CustomerDashBoardAccountSummaryModelInput : BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerDashBoardAccountSummaryModelOutput : BaseClassOutput
    {

        [JsonProperty("CCMS")]
        [DataMember]
        public string CCMS { get; set; }

        [JsonProperty("CardCash")]
        [DataMember]
        public string CardCash { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public string Drivestars { get; set; }

        [JsonProperty("LastUpdateForCCMS")]
        [DataMember]
        public string LastUpdateForCCMS { get; set; }

        [JsonProperty("LastUpdateForCardCash")]
        [DataMember]
        public string LastUpdateForCardCash { get; set; }

        [JsonProperty("LastUpdateForDrivestars")]
        [DataMember]
        public string LastUpdateForDrivestars { get; set; }
    }
}
