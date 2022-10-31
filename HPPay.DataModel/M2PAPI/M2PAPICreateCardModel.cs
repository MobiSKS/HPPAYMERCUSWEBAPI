using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.M2PAPI
{
    public class M2PAPICreateCardModelInput:M2PAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("VehicleFormType")]
        [DataMember]
        public string VehicleFormType { get; set; }

        [Required]
        [JsonPropertyName("M2PCustomerID")]
        [DataMember]
        public string M2PCustomerID { get; set; }

        [Required]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }


        [Required]
        [JsonPropertyName("Recordstatus")]
        [DataMember]
        public string Recordstatus { get; set; }

        [Required]
        [JsonPropertyName("CardDetail")]
        [DataMember]
        public MAPICardDetail CardDetail { get; set; }
    }

    public class MAPICardDetail
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9''']+$", ErrorMessage = "Invalid Vehicle Number")]
        [StringLength(22, MinimumLength = 5, ErrorMessage = "Invalid length of Vehicle Number, Should be between 5 to 22.")]
        [JsonPropertyName("VehicleRegistrationNumber")]
        [DataMember]
        public string VehicleRegistrationNumber { get; set; }

        [Required]
        [Range(0.00, 999999999.99, ErrorMessage = "Credit Daily sale Limit should be between 0 to 999999999.99")]
        [JsonPropertyName("CreditDailysaleLimit")]
        [DataMember]
        public decimal CreditDailysaleLimit { get; set; }


        [Required]
        [JsonPropertyName("ItemsEnabledDiesel")]
        [DataMember]
        public string ItemsEnabledDiesel { get; set; }
    }

    public class M2PAPICreateCardModelOutput
    {
        [JsonProperty("cardRes")]
        [DataMember]
        public GetcardRes cardRes { get; set; }

    }
    public class GetcardRes
    {

        [JsonProperty("cardDetail")]
        [DataMember]
        public cardDetailsfinaloutput cardDetail { get; set; }
    }
    public class cardDetailsfinaloutput
    {
        [JsonProperty("cardRes")]
        [DataMember]
        public List<GetcardRes> cardRes { get; set; }

        [JsonProperty("M2PCustomerID")]
        [DataMember]
        public string M2PCustomerID { get; set; }

        [JsonProperty("dtpCustomerID")]
        [DataMember]
        public string dtpCustomerID { get; set; }

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("vehicleRegnNo")]
        [DataMember]
        public string vehicleRegnNo { get; set; }

        [JsonProperty("cardIssuedDate")]
        [DataMember]
        public string cardIssuedDate { get; set; }

        [JsonProperty("creditDailySaleLimit")]
        [DataMember]
        public decimal creditDailySaleLimit { get; set; }


        [JsonProperty("nameonCard")]
        [DataMember]
        public string nameonCard { get; set; }

        [JsonProperty("ItemsEnabledDiesel")]
        [DataMember]
        public string ItemsEnabledDiesel { get; set; }

        [JsonProperty("statusCode")]
        [DataMember]
        public string statusCode { get; set; }

        [JsonProperty("message")]
        [DataMember]
        public string message { get; set; }
    }

}
