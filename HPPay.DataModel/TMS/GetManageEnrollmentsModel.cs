using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.TMS
{
    public class GetManageEnrollmentsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
    public class GetManageEnrollmentsModelOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("ContactNo")]
        [DataMember]
        public string ContactNo { get; set; }

        [JsonProperty("TMSUserId")]
        [DataMember]
        public string TMSUserId { get; set; }

        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        [DataMember]
        public string city { get; set; }

        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }

        [JsonProperty("PinCode")]
        [DataMember]
        public string PinCode { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("TMSStatus")]
        [DataMember]
        public string TMSStatus { get; set; }
    }

    public class GetTransportManagementSystemModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
    public class GetTransportManagementSystemModelOutput:BaseClassOutput
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
        public string Url { get; set; }
        public string TMSUserId { get; set; }
    }
}
