using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregatorNormalFleetCustomerModelInput : BaseClass
    {
       
        [JsonPropertyName("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
        [Required]
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


    }

    public class GetAggregatorNormalFleetCustomerModelOutput
    {


        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


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

        [JsonProperty("ApprovalComment")]
        [DataMember]
        public string ApprovalComment { get; set; }



    }
}
