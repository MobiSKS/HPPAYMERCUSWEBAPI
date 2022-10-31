using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIGetCustomerHotlistStatusModelInput : SFLAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("DtpCustomerId")]
        [DataMember]
        public string DtpCustomerId { get; set; }

        [Required]
        [JsonPropertyName("SFLCustomerId")]
        [DataMember]
        public string SFLCustomerId { get; set; }
    }

    public class SFLAPIGetCustomerHotlistStatusModelOutput 
    {
        [JsonProperty("customerHotlistDetails")]
        [DataMember]
        public List<GetcustomerHotlistDeatils> customerHotlistDetails { get; set; }
    }
    public class GetcustomerHotlistDeatils
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("dtpCustomerID")]
        [DataMember]
        public string dtpCustomerID { get; set; }

        [JsonProperty("sflCustomerId")]
        [DataMember]
        public string sflCustomerId { get; set; }

        [JsonProperty("hotlistStatus")]
        [DataMember]
        public string hotlistStatus { get; set; }

        [JsonProperty("hotlistReason")]
        [DataMember]
        public string hotlistReason { get; set; }
    }
}