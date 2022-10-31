using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.RBE
{

    public class GetRBECreationApprovalModelInput : BaseClass
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class GetRBECreationApprovalModelOutput
    {
        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }


        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("MakerComment")]
        [DataMember]
        public string MakerComment { get; set; }

        [JsonProperty("RequestOn")]
        [DataMember]
        public string RequestOn { get; set; }

        [JsonProperty("Requestedby")]
        [DataMember]
        public string Requestedby { get; set; }

        [JsonProperty("OfficerStatusId")]
        [DataMember]
        public string OfficerStatusId { get; set; }

        [JsonProperty("OfficerStatusName")]
        [DataMember]
        public string OfficerStatusName { get; set; }

    }
}
