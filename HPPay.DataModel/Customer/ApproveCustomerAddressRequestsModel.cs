using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class ApproveCustomerAddressRequestsModelInput : BaseClass
    {
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class ApproveCustomerAddressRequestsModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerCode")]
        [DataMember]

        public string CustomerCode { get; set; }

        [JsonProperty("City")]
        [DataMember]

        public string City { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]

        public string CreatedBy { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]

        public string CreatedDate { get; set; }

        [JsonProperty("ZO")]
        [DataMember]

        public string ZO { get; set; }

        [JsonProperty("Ro")]
        [DataMember]

        public string Ro { get; set; }

        [JsonProperty("Pan")]
        [DataMember]

        public string Pan { get; set; }

        [JsonProperty("PanCardRemarks")]
        [DataMember]

        public string PanCardRemarks { get; set; }
    }
}
