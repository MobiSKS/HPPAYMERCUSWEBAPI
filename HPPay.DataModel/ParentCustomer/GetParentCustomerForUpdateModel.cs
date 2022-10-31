using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerForUpdateModelInput:BaseClass
    {

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonPropertyName("RegionalId")]
        [DataMember]
        public string RegionalId { get; set; }

    }

    public class GetParentCustomerForUpdateModelOutput
    {

        [Required]
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [Required]
        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [Required]
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [Required]
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
        
        [Required]
        [JsonProperty("FormReceiptDate")]
        [DataMember]
        public DateTime FormReceiptDate { get; set; }

        [Required]
        [JsonProperty("Id")]
        [DataMember]
        public int Id { get; set; }
         

    }
}
