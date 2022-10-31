using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class CustomerCheckPancardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]
        public string IncomeTaxPan { get; set; }
    }
    public class CustomerCheckPancardModelOutput : BaseClassOutput
    {

    }

    public class CustomerCheckPancardbyDistrictIdModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]
        public string IncomeTaxPan { get; set; }

        [Required]
        [JsonPropertyName("DistrictId")]
        [DataMember]
        public string DistrictId { get; set; }
    }
    public class CustomerCheckPancardbyDistrictIdModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
    }

    public class CheckPancardbyDistrictIdAndCustomerReferenceNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]
        public string IncomeTaxPan { get; set; }

        [Required]
        [JsonPropertyName("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }
    public class CheckPancardbyDistrictIdAndCustomerReferenceNoModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

    }
}
