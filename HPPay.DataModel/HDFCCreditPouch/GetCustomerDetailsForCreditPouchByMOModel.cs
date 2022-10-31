using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
   
    public class GetCustomerDetailsForCreditPouchByMOModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

    }
    public class GetCustomerDetailsForCreditPouchByMOModelOutPut  :BaseClassOutput
    {

        [JsonProperty("GetCustomerInfo")]
        public List<GetCustomerInfo> GetCustomerInfo { get; set; }

        [JsonProperty("GetCustomerPrevInfo")]
        public List<GetCustomerPrevInfo> GetCustomerPrevInfo { get; set; }

    }
    public class GetCustomerInfo:BaseClassOutput
    {

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
        public decimal TotalSpend { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }


        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("ReqStatus")]
        [DataMember]
        public string ReqStatus { get; set; }

        [JsonProperty("EnrolledDate")]
        [DataMember]
        public string EnrolledDate { get; set; }

        [JsonProperty("Comment")]
        [DataMember]
        public string Comment { get; set; }

    }

    public class GetCustomerPrevInfo : BaseClassOutput
    {

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
        public decimal TotalSpend { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }


        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("ReqStatus")]
        [DataMember]
        public string ReqStatus { get; set; }

        [JsonProperty("EnrolledDate")]
        [DataMember]
        public string EnrolledDate { get; set; }

        [JsonProperty("Comment")]
        [DataMember]
        public string Comment { get; set; }

    }
}
