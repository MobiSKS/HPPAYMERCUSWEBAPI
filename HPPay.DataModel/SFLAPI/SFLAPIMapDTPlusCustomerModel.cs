using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIMapDTPlusCustomerModelInput:SFLAPIBaseClassInput
    {
        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN")]
        [StringLength(10, ErrorMessage = "Invalid PAN/PAN must be length of 10.")]
        [JsonPropertyName("PanNumber")]
        [DataMember]
        public string PanNumber { get; set; }

        [Required]
       
        [JsonPropertyName("SFCustomerID")]
        [DataMember]
        public string SFCustomerID { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid DTPCustomerId")]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }
    }
    public class SFLAPIMapDTPlusCustomerModelOutput : SFLAPIBaseClassOutput
    {

        [JsonProperty("SFCustomerID")]
        [DataMember]
        public string SFCustomerID { get; set; }

        [JsonProperty("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [JsonProperty("controlCardNumber")]
        [DataMember]
        public string controlCardNumber { get; set; }

        [JsonProperty("ifscCode")]
        [DataMember]
        public string ifscCode { get; set; }
    }

    public class SFLAPIMapDTPlusCustomerFailureResponseOutput : SFLAPIBaseClassOutput
    {

        [JsonProperty("SFCustomerID")]
        [DataMember]
        public string SFCustomerID { get; set; }

        [JsonProperty("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        
    }
}
