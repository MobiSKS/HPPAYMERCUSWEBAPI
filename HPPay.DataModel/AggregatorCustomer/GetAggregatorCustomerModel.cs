using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregatorCustomerModelInput : BaseClass
    {
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [Required]
        [JsonPropertyName("CustomerStatus")]
        [DataMember]
        public int CustomerStatus { get; set; }
    }
    public class GetAggregatorCustomerModelOutput
    {
        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
     
        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }

    }


    public class GetAggregatorStatusModelInput:BaseClass
    {

    }

    public class GetAggregatorStatusModelOutput 
    {
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public string StatusId { get; set; }
    }
}
