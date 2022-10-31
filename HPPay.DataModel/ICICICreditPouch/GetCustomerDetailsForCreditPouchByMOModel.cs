using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class GetICICICustomerDetailsForCreditPouchByMOModelInput : BaseClass
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
    public class GetICICICustomerDetailsForCreditPouchByMOModelOutPut:BaseClassOutput
    {      

        [JsonProperty("ICICICGetCustomerInfo")]
        public List<ICICICGetCustomerInfo> ICICICGetCustomerInfo { get; set; }

        [JsonProperty("ICICICGetCustomerPrevInfo")]
        public List<ICICICGetCustomerPrevInfo> ICICICGetCustomerPrevInfo { get; set; }

    }
    public class ICICICGetCustomerInfo : BaseClassOutput
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

    public class ICICICGetCustomerPrevInfo : BaseClassOutput
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
