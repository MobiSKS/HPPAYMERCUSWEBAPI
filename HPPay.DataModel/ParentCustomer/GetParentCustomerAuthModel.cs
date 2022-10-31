using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerAuthModelInput:BaseClass
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

    public class GetParentCustomerAuthModelOutput
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

        
        [JsonProperty("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        
        [JsonProperty("ApprovedDate")]
        [DataMember]
        public string ApprovedDate { get; set; }

        
        [JsonProperty("Id")]
        [DataMember]
        public int Id { get; set; }

        
        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

    }
}
