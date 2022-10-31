using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPICreateCardModelInput : SFLAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("VehicleFormType")]
        [DataMember]
        public string VehicleFormType { get; set; }

        [Required]
        [JsonPropertyName("SFCustomerID")]
        [DataMember]
        public string SFCustomerID { get; set; }

        [Required]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        [JsonPropertyName("Recordstatus")]
        [DataMember]
        public string Recordstatus { get; set; }

     
        [JsonProperty("CardDetail")]
        [DataMember]
        public GetCardDetails CardDetail { get; set; }
    }
    public class GetCardDetails

    {
        [Required]
        [JsonPropertyName("VehicleRegistrationNumber")]
        [DataMember]
        public string VehicleRegistrationNumber { get; set; }


        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Invalid cardNumber/cardNumber should be length of 16 digits.")]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [Required]
        [Range(1.00, 1000000.00, ErrorMessage = "Credit Daily sale Limit should be between 1 to 10 Lac.")]
        [JsonPropertyName("CreditDailysaleLimit")]
        [DataMember]
        public decimal CreditDailysaleLimit { get; set; }

        
        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonPropertyName("AssetSerialNumber")]
        [DataMember]
        public string AssetSerialNumber { get; set; }

       
        [JsonPropertyName("VehicleAssetType")]
        [DataMember]
        public string VehicleAssetType { get; set; }

     
        [JsonPropertyName("ItemsEnabledDiesel")]
        [DataMember]
        public string ItemsEnabledDiesel { get; set; }
    }


    public class SFLAPICreateCardModelOutput
    {
        [JsonProperty("cardRes")]
        [DataMember]
        public GetcardRes cardRes { get; set; }

    }
    public class GetcardRes
    {

        [JsonProperty("cardDetail")]
        [DataMember]
        public cardDetailsFinaloutput cardDetail { get; set; }
    }

    public class cardDetailsFinaloutput 
    {

        [JsonProperty("sfCustomerID")]
        [DataMember]
        public string sfCustomerID { get; set; }

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

        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }

        [JsonProperty("assetSerialNumber")]
        [DataMember]
        public string assetSerialNumber { get; set; }


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
