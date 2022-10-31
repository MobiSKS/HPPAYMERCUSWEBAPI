using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.ParentCustomer
{
    public class ParentCustomerReportStatusModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [Required]
        [JsonPropertyName("RequestId")]
        [DataMember]
        public int RequestId { get; set; }
    }
    public class ParentCustomerReportStatusModelOutput:BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [Required]
        [JsonProperty("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }


        [Required]
        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [Required]
        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }
       
        [Required]
        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [Required]
        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [Required]
        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }

        [Required]
        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("SBUTypeName")]
        [DataMember]
        public string SBUTypeName { get; set; }
 

    }

}
