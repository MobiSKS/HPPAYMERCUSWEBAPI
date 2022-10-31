using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetUpdateContactPersonDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetUpdateContactPersonDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("Title")]
        [DataMember]
        public string Title { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName")]
        [DataMember]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("Designation")]
        [DataMember]
        public string Designation { get; set; }

        [JsonProperty("Ph_Office")]
        [DataMember]
        public string Ph_Office { get; set; }

        [JsonProperty("Fax")]
        [DataMember]
        public string Fax { get; set; }


        [JsonProperty("DateofAnniversary")]
        [DataMember]
        public string DateofAnniversary { get; set; }

        [JsonProperty("IndividualInitial")]
        [DataMember]
        public string IndividualInitial { get; set; }

        [JsonProperty("DateOfBirth")]
        [DataMember]
        public string DateOfBirth { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }
    }
}
