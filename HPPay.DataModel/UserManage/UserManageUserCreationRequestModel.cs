using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.UserManage
{
    public class UserManageUserCreationRequestModelInput:BaseClass
    {

        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("MiddleName")]
        [DataMember]
        public string MiddleName { get; set; }

        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }


        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [JsonPropertyName("UserRole")]
        [DataMember]
        public int UserRole { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("TypeUserCreationDetails")]
        [DataMember]
        public List<TypeUserCreationDetails> TypeUserCreationDetails { get; set; }
    }

    public class TypeUserCreationDetails
    {

        [JsonPropertyName("ZO")]
        [DataMember]
        public int ZO { get; set; }

        [JsonPropertyName("RO")]
        [DataMember]
        public int RO { get; set; }

    }

    public class UserManageUserCreationRequestModelOutput : BaseClassOutput
    {

    }
}

