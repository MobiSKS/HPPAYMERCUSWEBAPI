using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class GetICICICreditPouchDetalsForAuthInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


    }
    public class GetICICICreditPouchDetalsForAuthOutPut
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("LastTransactionDate")]
        [DataMember]
        public string LastTransactionDate { get; set; }

        [JsonProperty("TotalSpend")]
        [DataMember]
        public int TotalSpend { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [JsonProperty("ApprovedDate")]
        [DataMember]
        public string ApprovedDate { get; set; }

        [JsonProperty("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonProperty("RequestNo")]
        [DataMember]
        public int RequestNo { get; set; }

        [JsonProperty("ActionStatus")]
        [DataMember]
        public string ActionStatus { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("PlanId")]
        [DataMember]
        public string PlanId { get; set; }

    }
}
