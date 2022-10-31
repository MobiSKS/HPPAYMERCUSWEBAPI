using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class AddOnCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public Int32 NoOfCards { get; set; }

        //[Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        //[Required]
        [JsonPropertyName("FeePaymentsCollectFeeWaiver")]
        [DataMember]
        public Int16 FeePaymentsCollectFeeWaiver { get; set; }

        //[Required]
        [JsonPropertyName("FeePaymentNo")]
        [DataMember]
        public string FeePaymentNo { get; set; }

        //[Required]
        [JsonPropertyName("FeePaymentDate")]
        [DataMember]
        public DateTime FeePaymentDate { get; set; }
        
        [JsonPropertyName("ObjCardDetail")]
        [DataMember]
        public List<AddonCardDetails> ObjCardDetail { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }

        //[Required]
        [JsonPropertyName("NoofVechileforAllCards")]
        [DataMember]
        public Int32 NoofVechileforAllCards { get; set; }

        [JsonPropertyName("VehicleNoVerifiedManually")]
        [DataMember]
        public Int32 VehicleNoVerifiedManually { get; set; }
    }

    public class AddonCardDetails
    {
        [JsonPropertyName("CardIdentifier")]
        public string CardIdentifier { get; set; }

        [JsonPropertyName("VechileNo")]
        public string VechileNo { get; set; }

        [JsonPropertyName("VehicleType")]
        public string VehicleType { get; set; }

        [JsonPropertyName("VehicleMake")]
        public string VehicleMake { get; set; }

        [JsonPropertyName("YearOfRegistration")]
        public int YearOfRegistration { get; set; }
        [JsonPropertyName("MobileNo")]
        public string MobileNo { get; set; }
    }

    public class AddOnCardModelOutput : BaseClassOutput
    {

    }
}
