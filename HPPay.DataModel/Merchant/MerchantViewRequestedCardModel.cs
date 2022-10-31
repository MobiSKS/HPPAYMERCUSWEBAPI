using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantViewRequestedCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RegionalId")]
        [DataMember]
        public Int32 RegionalId { get; set; }
    }

    public class MerchantViewRequestedCardModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }

        [JsonProperty("AssignStatus")]
        [DataMember]
        public string AssignStatus { get; set; }

    }
}
