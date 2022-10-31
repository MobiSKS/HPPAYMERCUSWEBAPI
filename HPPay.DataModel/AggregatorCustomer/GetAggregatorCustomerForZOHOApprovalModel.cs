using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregatorCustomerForZOHOApprovalModelInput:BaseClass
    {
       
    }


    public class GetAggregatorCustomerForZOHOApprovalModelOutput:BaseClassOutput
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
}
