using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RBEUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }



        [Required]
        [StringLength(10, MinimumLength = 10)]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }


        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }


        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }
    }

    public class RBEUpdateModelOutput : BaseClassOutput
    {

    }

}
