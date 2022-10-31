using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
   

    public class AddOnCardRequestWithPaymentModelInput : BaseClass
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

  
        [Required]
        [JsonPropertyName("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }

        [Required]
        [JsonPropertyName("ObjAddOnCardDetail")]
        [DataMember]
        public List<CustomerAddonCardDetails> ObjAddOnCardDetail { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("NoofVechileforAllCards")]
        [DataMember]
        public Int32 NoofVechileforAllCards { get; set; }

        [JsonPropertyName("VehicleNoVerifiedManually")]
        [DataMember]
        public Int32 VehicleNoVerifiedManually { get; set; }

        [Required]
        [JsonPropertyName("PaymentMethod")]
        [DataMember]
        public Int32 PaymentMethod { get; set; }

      
    }

    public class CustomerAddonCardDetails
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

    public class AddOnCardRequestWithPaymentModelOutput : BaseClassOutput
    {

    }
}
