using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class ChangeRBEMappingModelInput : BaseClass
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class ChangeRBEMappingModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }

        [JsonProperty("Zone")]
        [DataMember]
        public string Zone { get; set; }

        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }
    }
    public class ManageRBEUserModelInput : BaseClass
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class ManageRBEUserModelOutput
    {
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }

        [JsonProperty("Zone")]
        [DataMember]
        public string Zone { get; set; }

        [JsonProperty("ViewKYC")]
        [DataMember]
        public string ViewKYC { get; set; }
    }
}
