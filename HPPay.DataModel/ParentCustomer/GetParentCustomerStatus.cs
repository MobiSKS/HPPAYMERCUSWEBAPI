using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerStatusModelInput : BaseClass
    {

        
        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }

        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }

      
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

     
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

   
        [JsonPropertyName("FormId")]
        [DataMember]
        public Int64 FormId { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public string SBUTypeId { get; set; }
    }

    public class GetParentCustomerStatusModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("RequestId")]
        [DataMember]
        public Int32 RequestId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

        [JsonProperty("SBUTypeName")]
        [DataMember]
        public string SBUTypeName { get; set; }

    }
}
