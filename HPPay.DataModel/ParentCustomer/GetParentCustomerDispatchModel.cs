using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{ 
    
    public class GetParentCustomerDispatchModelInput : BaseClass
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

    public class GetParentCustomerDispatchDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("DispatchDate")]
        [DataMember]
        public string DispatchDate { get; set; }

        [JsonProperty("DispatchNo")]
        [DataMember]
        public string DispatchNo { get; set; }
    }

}
