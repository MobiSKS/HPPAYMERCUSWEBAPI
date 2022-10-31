using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALPendingKycCustomerModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
    public class GetALPendingKycCustomerModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }
        [JsonProperty("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }



    }
}
