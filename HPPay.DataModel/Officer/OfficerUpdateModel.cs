using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{
    public class OfficerUpdateModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }
         

        //[Required]
        [JsonPropertyName("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonPropertyName("Address2")]
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

        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }

        //[Required]
        [StringLength(10, MinimumLength = 10)]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        //[Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }


        [JsonPropertyName("Fax")]
        [DataMember]
        public string Fax { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("OfficerId")]
        [DataMember]
        public int OfficerId { get; set; }

    }

   

    public class OfficerUpdateModelOutput : BaseClassOutput
    {
        
    }
 
}
