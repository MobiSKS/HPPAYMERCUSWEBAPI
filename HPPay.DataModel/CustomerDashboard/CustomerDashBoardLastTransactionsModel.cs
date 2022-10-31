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
    public class CustomerDashBoardLastTransactionsModelInput : BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerDashBoardLastTransactionsModelOutput : BaseClassOutput
    {

        [JsonProperty("AccountNo")]
        [DataMember]
        public string AccountNo { get; set; }

        [JsonProperty("VehicleNo_UserName")]
        [DataMember]
        public string VehicleNo_UserName { get; set; }

        [JsonProperty("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonProperty("TxnType")]
        [DataMember]
        public string TxnType { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }
    }
}
