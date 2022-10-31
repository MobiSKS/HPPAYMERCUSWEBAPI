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
    public class PCChildCustomerBalanceInfoModelInput : BaseClass
    {

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }
    public class PCChildCustomerBalanceInfoModelOutPut : BaseClassOutput
    {

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("LastDateOfTransaction")]
        [DataMember]
        public string LastDateOfTransaction { get; set; }

        [JsonProperty("VehicleNo_UserName")]
        [DataMember]
        public string VehicleNo_UserName { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }
    }
}
