using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    

    public class UpdateALDealerEnrollmentModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [Required]
        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public int ZonalOfficeId { get; set; }

        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public int RegionalOfficeId { get; set; }


        [Required]
        [JsonPropertyName("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonPropertyName("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonPropertyName("Address3")]
        [DataMember]
        public string Address3 { get; set; }

        [Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [Required]
        [JsonPropertyName("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [Required]
        [JsonPropertyName("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        [Required]
        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }

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

    }

    public class UpdateALDealerEnrollmentModelOutput : BaseClassOutput
    {
        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("DealerId")]
        [DataMember]
        public Int64 DealerId { get; set; }
    }
}
