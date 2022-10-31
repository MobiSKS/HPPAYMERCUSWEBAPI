using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserCreationRequestViewModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

      
    }
    public class UserCreationRequestViewModelOutput : BaseClassOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("Email")]
        [DataMember]

        public string Email { get; set; }

        [JsonProperty("MakerComment")]
        [DataMember]

        public string MakerComment { get; set; }

        [JsonProperty("CheckerComment")]
        [DataMember]

        public string CheckerComment { get; set; }

        [JsonProperty("RequestedOn")]
        [DataMember]

        public string RequestedOn { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]

        public string RequestedBy { get; set; }

        [JsonProperty("ApprovedOn")]
        [DataMember]

        public string ApprovedOn { get; set; }

        [JsonProperty("ApprovedBy")]
        [DataMember]

        public string ApprovedBy { get; set; }

        [JsonProperty("IsApproved")]
        [DataMember]

        public string IsApproved { get; set; }


    }
}
