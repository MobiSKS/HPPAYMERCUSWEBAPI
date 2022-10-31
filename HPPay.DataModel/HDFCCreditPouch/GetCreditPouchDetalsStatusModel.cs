using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class GetCreditPouchStatusInput : BaseClass
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
         
        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }
         
        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }


        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class GetCreditPouchStatusOutPut
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
         
        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }
         

        [JsonProperty("ApproverRemark")]
        [DataMember]
        public string ApproverRemark { get; set; }

        [JsonProperty("EnrolledBy")]
        [DataMember]
        public string EnrolledBy { get; set; }

        [JsonProperty("EnrolledDate")]
        [DataMember]
        public string EnrolledDate { get; set; }
         

        [JsonProperty("AuthorizerRemark")]
        [DataMember]
        public string AuthorizerRemark { get; set; }

        [JsonProperty("RequestNo")]
        [DataMember]
        public int RequestNo { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("CreditLimitAssigned")]
        [DataMember]
        public decimal CreditLimitAssigned { get; set; }

        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }


        [JsonProperty("SBUTypeName")]
        [DataMember]
        public string SBUTypeName { get; set; }

    }
}
