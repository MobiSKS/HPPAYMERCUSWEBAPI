using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class InsertICICICreditPouchDetailsByCustomerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
         
        [JsonPropertyName("FuleConsumptionCapacity")]
        [DataMember]
        public decimal FuleConsumptionCapacity { get; set; }

         
        [JsonPropertyName("PlanTypeId")]
        [DataMember]
        public int PlanTypeId { get; set; }

         
        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [Required]
        [JsonPropertyName("CustomerRemarks")]
        [DataMember]
        public string CustomerRemarks { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public int ActionType { get; set; }

        [Required]
        [JsonPropertyName("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

    }
    public class InsertICICICreditPouchDetailsByCustomerModelOutput : BaseClassOutput
    {
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("Plan")]
        [DataMember]
        public string Plan { get; set; }


        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }

    }
}
