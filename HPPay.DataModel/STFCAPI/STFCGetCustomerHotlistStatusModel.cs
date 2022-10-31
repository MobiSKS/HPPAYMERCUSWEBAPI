using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.STFCAPI
{
    public class STFCGetCustomerHotlistStatusModelInput:STFCAPIBaseClassInput
    {


        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid DtpCustomerId/DtpCustomerId should be length of 10 digits.")]
        [JsonPropertyName("DtpCustomerId")]
        [DataMember]
        public string DtpCustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z]{1,15}$", ErrorMessage = "Invalid STFCCustomerID")]
        [JsonPropertyName("StfcCustomerId")]
        [DataMember]
        public string StfcCustomerId { get; set; }
    }

    public class STFCGetCustomerHotlistStatusModelOutput 
    {
        [JsonProperty("customerHotlistDeatils")]
        [DataMember]
        public GetcustomerHotlistDeatils customerHotlistDeatils { get; set; }
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

        [JsonProperty("stfcCustomerId")]
        [DataMember]
        public string stfcCustomerId { get; set; }

        [JsonProperty("hotlistStatus")]
        [DataMember]
        public string hotlistStatus { get; set; }

        [JsonProperty("hotlistReason")]
        [DataMember]
        public string hotlistReason { get; set; }
    }
}
