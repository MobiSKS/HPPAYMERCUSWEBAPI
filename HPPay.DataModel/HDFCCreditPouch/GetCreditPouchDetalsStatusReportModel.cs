using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class GetCreditPouchDetalsStatusReportInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("RequestId")]
        [DataMember]
        public string RequestId { get; set; }
    }
    public class GetCreditPouchStatusReportOutPut
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
         

        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("RequestNo")]
        [DataMember]
        public int RequestNo { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }


        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }
}
