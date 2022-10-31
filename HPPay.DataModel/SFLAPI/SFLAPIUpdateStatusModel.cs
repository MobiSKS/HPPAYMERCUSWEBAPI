using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIUpdateStatusModelInput : SFLAPIBaseClassInput
    {
        [Required]
        [RegularExpression("^[1-2]{1}$", ErrorMessage = "Invalid ApplicabilityCustomerCard")]

        [JsonPropertyName("ApplicabilityCustomerCard")]
        [DataMember]
        public string ApplicabilityCustomerCard { get; set; }

        [Required]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }
        
        [Required]
        [RegularExpression(@"\d{6}", ErrorMessage = "Invalid ReferenceNumber should be length of 6 digits.")]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Card Customer Status Code")]
        [JsonPropertyName("CardCustomerStatusCode")]
        [DataMember]
        public string CardCustomerStatusCode { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Previous Card Status Code")]
        [JsonPropertyName("PreviousCardStatusCode")]
        [DataMember]
        public string PreviousCardStatusCode { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "StatusChangeReasonCode Must be a maximum of 4 characters")]
        [JsonPropertyName("StatusChangeReasonCode")]
        [DataMember]
        public string StatusChangeReasonCode { get; set; }
    }

    public class SFLAPIUpdateStatusModelOutputMain
    {
        [JsonProperty("customerCardStatusRes")]
        [DataMember]
        public SFLAPIUpdateStatusModelMainOutput customerCardStatusRes { get; set; }
    }

    public class SFLAPIUpdateStatusModelMainOutput : SFLAPIBaseClassOutput
    {

        [JsonProperty("entityDetails")]
        [DataMember]
        public entityDetail entityDetails { get; set; }
    }

    public class SFLAPIUpdateStatusModelOutput
    {

        [JsonProperty("customerCardStatusRes")]
        [DataMember]
        public GetcustomerCardStatusRes customerCardStatusRes { get; set; }


        [JsonProperty("entityDetails")]
        [DataMember]
        public entityDetail entityDetails { get; set; }
    }

    public class GetcustomerCardStatusRes
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public class entityDetail
    {
        [JsonProperty("applicability")]
        [DataMember]
        public string applicability { get; set; }

        [JsonProperty("dtpCustomerID")]
        [DataMember]
        public string dtpCustomerID { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }


        [JsonProperty("referenceNumber")]
        [DataMember]
        public string referenceNumber { get; set; }


        [JsonProperty("customerCardStatusCode")]
        [DataMember]
        public string customerCardStatusCode { get; set; }


        [JsonProperty("previousCardStatusCode")]
        [DataMember]
        public string previousCardStatusCode { get; set; }

        [JsonProperty("statusChangeReasonCode")]
        [DataMember]
        public string statusChangeReasonCode { get; set; }

        [JsonProperty("statusChangeAdvisedBy")]
        [DataMember]
        public string statusChangeAdvisedBy { get; set; }


        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }

    }
}