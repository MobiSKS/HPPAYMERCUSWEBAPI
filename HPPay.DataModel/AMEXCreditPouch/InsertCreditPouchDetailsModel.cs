using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AMEXCreditPouch
{
    public  class InsertAMEXCreditPouchDetailsModelInput : BaseClass
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
        [JsonPropertyName("MoComment")]
        [DataMember]
        public string MoComment { get; set; }

        [Required]
        [JsonPropertyName("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }
    public class InsertAMEXCreditPouchDetailsModelOutPut : BaseClassOutput
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
