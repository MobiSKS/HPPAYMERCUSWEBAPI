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
    public class CustomerDashBoardReminderModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
    public class CustomerDashBoardReminderModelOutput : BaseClassOutput
    {

        [JsonProperty("ExpiringDrivestars")]
        [DataMember]
        public string ExpiringDrivestars { get; set; }

        [JsonProperty("ExpiringCards")]
        [DataMember]
        public string ExpiringCards { get; set; }

    }
}
