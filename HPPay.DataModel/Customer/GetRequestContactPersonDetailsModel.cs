using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class RequestGetApproveCustomerContactPersonDetailsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }

    public class RequestGetApproveCustomerContactPersonDetailsModelOutput
    {
        [JsonProperty("ObjOldCustomerContactValue")]
        public List<GetContactPersonDetails> ObjOldCustomerContactValue { get; set; }

        
    
        [JsonProperty("ObjNewCustomerContactValue")]
        public List<GetDetailRequestGetApproveCustomerContactPersonDetails> ObjNewCustomerContactValue { get; set; }
    }

    public class GetContactPersonDetails
    {

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("KeyOfficialTitle")]
        [DataMember]

        public string KeyOfficialTitle { get; set; }

        [JsonProperty("KeyOfficialFirstName")]
        [DataMember]

        public string KeyOfficialFirstName { get; set; }

        [JsonProperty("KeyOfficialMiddleName")]
        [DataMember]

        public string KeyOfficialMiddleName { get; set; }

        [JsonProperty("KeyOfficialLastName")]
        [DataMember]

        public string KeyOfficialLastName { get; set; }

        [JsonProperty("KeyOfficialDesignation")]
        [DataMember]

        public string KeyOfficialDesignation { get; set; }

        [JsonProperty("KeyOfficialPhoneNo")]
        [DataMember]

        public string KeyOfficialPhoneNo { get; set; }

        [JsonProperty("KeyOfficialFax")]
        [DataMember]

        public string KeyOfficialFax { get; set; }

        [JsonProperty("KeyOfficialDOA")]
        [DataMember]

        public string KeyOfficialDOA { get; set; }

        [JsonProperty("KeyOfficialDOB")]
        [DataMember]

        public string KeyOfficialDOB { get; set; }

        [JsonProperty("KeyOfficialIndividualInitials")]
        [DataMember]

        public string KeyOfficialIndividualInitials { get; set; }

        [JsonProperty("KeyOfficialMobile")]
        [DataMember]

        public string KeyOfficialMobile { get; set; }

        [JsonProperty("KeyOfficialEmail")]
        [DataMember]

        public string KeyOfficialEmail { get; set; }
    }
    public class GetDetailRequestGetApproveCustomerContactPersonDetails
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("KeyOfficialTitle")]
        [DataMember]

        public string KeyOfficialTitle { get; set; }

        [JsonProperty("KeyOfficialFirstName")]
        [DataMember]

        public string KeyOfficialFirstName { get; set; }

        [JsonProperty("KeyOfficialMiddleName")]
        [DataMember]

        public string KeyOfficialMiddleName { get; set; }

        [JsonProperty("KeyOfficialLastName")]
        [DataMember]

        public string KeyOfficialLastName { get; set; }

        [JsonProperty("KeyOfficialDesignation")]
        [DataMember]

        public string KeyOfficialDesignation { get; set; }

        [JsonProperty("KeyOfficialPhoneNo")]
        [DataMember]

        public string KeyOfficialPhoneNo { get; set; }

        [JsonProperty("KeyOfficialFax")]
        [DataMember]

        public string KeyOfficialFax { get; set; }

        [JsonProperty("KeyOfficialDOA")]
        [DataMember]

        public string KeyOfficialDOA { get; set; }

        [JsonProperty("KeyOfficialDOB")]
        [DataMember]

        public string KeyOfficialDOB { get; set; }

        [JsonProperty("KeyOfficialIndividualInitials")]
        [DataMember]

        public string KeyOfficialIndividualInitials { get; set; }

        [JsonProperty("KeyOfficialMobile")]
        [DataMember]

        public string KeyOfficialMobile { get; set; }

        [JsonProperty("KeyOfficialEmail")]
        [DataMember]

        public string KeyOfficialEmail { get; set; }
    }
}
