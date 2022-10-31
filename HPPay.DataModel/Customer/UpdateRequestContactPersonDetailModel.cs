using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class UpdateRequestContactPersonDetailsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("KeyOfficialTitle")]
        [DataMember]
        public string KeyOfficialTitle { get; set; }

        [JsonPropertyName("KeyOfficialFirstName")]
        [DataMember]
        public string KeyOfficialFirstName { get; set; }

        [JsonPropertyName("KeyOfficialMiddleName")]
        [DataMember]
        public string KeyOfficialMiddleName { get; set; }

        [JsonPropertyName("KeyOfficialLastName")]
        [DataMember]
        public string KeyOfficialLastName { get; set; }

        [JsonPropertyName("KeyOfficialDesignation")]
        [DataMember]
        public string KeyOfficialDesignation { get; set; }

        [JsonPropertyName("KeyOfficialPhoneNo")]
        [DataMember]
        public string KeyOfficialPhoneNo { get; set; }

        [JsonPropertyName("KeyOfficialFax")]
        [DataMember]
        public string KeyOfficialFax { get; set; }


        [JsonPropertyName("KeyOfficialDOA")]
        [DataMember]
        public string KeyOfficialDOA { get; set; }

        [JsonPropertyName("KeyOfficialIndividualInitial")]
        [DataMember]
        public string KeyOfficialIndividualInitial { get; set; }

        [JsonPropertyName("KeyOfficialMobile")]
        [DataMember]
        public string KeyOfficialMobile { get; set; }

        [JsonPropertyName("KeyOfficialDOB")]
        [DataMember]
        public string KeyOfficialDOB { get; set; }

        [JsonPropertyName("KeyOfficialEmail")]
        [DataMember]
        public string KeyOfficialEmail { get; set; }
    }
    public class UpdateRequestContactPersonDetailsModelOutput : BaseClassOutput
    {

    }
}

