using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class MapFacilityModelInput
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [JsonPropertyName("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

        [Required]
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }
    }

    public class MapFacilityModelOutPut:BaseClassOutput
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


        [JsonProperty("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }


        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

      

        [JsonProperty("tblThirdPartyCustomers2")]
        public List<CardListModel> tblThirdPartyCustomers2 { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }


    }

    public class CardListModel
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
