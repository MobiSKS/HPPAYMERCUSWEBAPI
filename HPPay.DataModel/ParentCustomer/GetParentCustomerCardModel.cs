using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerCardModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("RequestId")]
        [DataMember]
        public int RequestId { get; set; }

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }

    public class GetParentCustomerCardDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("VehicalNo")]
        [DataMember]
        public string VehicalNo { get; set; }

        [JsonProperty("IssueDate")]
        [DataMember]
        public DateTime IssueDate { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public int CardStatus { get; set; }
    }

}
