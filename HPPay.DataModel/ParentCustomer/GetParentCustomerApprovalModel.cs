using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerApprovalModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public DateTime FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public DateTime ToDate { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

    }

    public class GetParentCustomerApprovalModelOutput
    {
        
        
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        
        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

         
        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

         
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

         
        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }

         
        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

         
        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

         
        [JsonProperty("Id")]
        [DataMember]
        public int Id { get; set; }

    }
}
