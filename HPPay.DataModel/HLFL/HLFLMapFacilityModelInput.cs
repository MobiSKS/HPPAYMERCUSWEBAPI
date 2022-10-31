using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HLFL
{
    public class HLFLMapFacilityModelInput
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [RegularExpression(@"^([FCfc]){2}([0-9]){7}$", ErrorMessage = "Invalid Facility Number.")]
        [JsonPropertyName("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

        [Required]
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }
    }

    public class HLFLMapFacilityModelOutPut
    { 


        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }


        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonProperty("CardListModel")]
        public List<HLFLCardListModel> CardListModel { get; set; }
    }


    public class HLFLCardListModel
    {

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }



        [JsonProperty("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }



        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("RegistrationYear")]
        [DataMember]
        public string RegistrationYear { get; set; }


        [JsonProperty("CardPreferenceType")]
        [DataMember]
        public string CardPreferenceType { get; set; }


        [JsonProperty("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }

    }

}
