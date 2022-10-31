using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.TMS
{
    public class GetEnrollTransportManagementSystemModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class GetEnrollTransportManagementSystemModelOutput : BaseClassOutput
    {

    }

    public class GetCustomerDetailForEnrollmentApprovalInput:BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID  { get; set; }
        [JsonPropertyName("TMSUserId")]
        [DataMember]
        public string TMSUserId { get; set; }
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string  ToDate { get; set; }
        [JsonPropertyName("TMSStatus")]
        [DataMember]
        public int TMSStatus { get; set; }

    }

    public class GetCustomerDetailForEnrollmentApprovalOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }
        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }
        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }
        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }
        [JsonProperty("Remark")]
        [DataMember]
        public string Remark { get; set; }

        
        [JsonProperty("TMSApprovedBy")]
        [DataMember]
        public string TMSApprovedBy { get; set; }

        [JsonProperty("TMSApprovedon")]
        [DataMember]
        public string TMSApprovedon { get; set; }

        [JsonProperty("TMSUserId")]
        [DataMember]
        public string TMSUserId { get; set; }


    }
}
