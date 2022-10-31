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
    public  class SetCustomerCardDispatchInputModel: BaseClass
    {

        [JsonPropertyName("Zonalid")]
        [DataMember]
        public string Zonalid { get; set; }

        [JsonPropertyName("Regionalid")]
        [DataMember]
        public string Regionalid { get; set; }


        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string  ToDate { get; set; }
    }

    public class SetCustomerCardDispatchOutputModel: BaseClassOutput
    {

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZOID")]
        [DataMember]
        public int ZOID { get; set; }

        [JsonProperty("ROID")]
        [DataMember]
        public int ROID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("CustomerCode")]
        [DataMember]
        public string CustomerID { get; set; }

    }
}
