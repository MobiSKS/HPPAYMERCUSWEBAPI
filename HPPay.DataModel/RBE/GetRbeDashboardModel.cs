using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetRbeDashboardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }

    public class GetRbeDashboardModelOutput
    {
        [JsonProperty("NewEnrollmentCount")]
        [DataMember]
        public Int32 NewEnrollmentCount { get; set; }

        [JsonProperty("NewCardCount")]
        [DataMember]
        public Int32 NewCardCount { get; set; }

        [JsonProperty("PendingVisitCount")]
        [DataMember]
        public Int32 PendingVisitCount { get; set; }

        [JsonProperty("CompletedVisitCount")]
        [DataMember]
        public Int32 CompletedVisitCount { get; set; }
    }
}
