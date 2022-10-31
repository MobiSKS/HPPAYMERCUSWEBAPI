using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class InsertRBEModelInput : BaseClass
    {

        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }


        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        //[StringLength(8, MinimumLength = 8)]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }


        [Required]
        [JsonPropertyName("LocationId")]
        [DataMember]
        public int LocationId { get; set; }


        [JsonPropertyName("Address1")]
        [DataMember]
        public string Address1 { get; set; }


        [DataMember]
        public string Address2 { get; set; }

        [JsonPropertyName("Address3")]
        [DataMember]
        public string Address3 { get; set; }

        //[Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }

        //[Required]
        [JsonPropertyName("CityName")]
        [DataMember]
        public string CityName { get; set; }

        //[Required]
        [JsonPropertyName("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        //[Required]
        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }

        //[Required]
        //[StringLength(10, MinimumLength = 10)]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        //[Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        //[RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }


        [JsonPropertyName("Fax")]
        [DataMember]
        public string Fax { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

    }

    public class InsertRBEModelOutput : BaseClassOutput
    {


        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("OfficerID")]
        [DataMember]
        public int OfficerID { get; set; }

    }
}
