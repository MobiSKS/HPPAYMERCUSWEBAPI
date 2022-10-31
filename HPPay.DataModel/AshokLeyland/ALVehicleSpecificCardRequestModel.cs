using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALVehicleSpecificCardRequestModelInput:BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetALVehicleSpecificCardRequestModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [JsonProperty("VINNumber")]
        [DataMember]
        public string VINNumber { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }
    }

    public class InsertALVehicleSpecificCardRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("lstVehicleSpecificCard")]
        [DataMember]
        public List<ALVehicleSpecificCard> lstVehicleSpecificCard { get; set; }
    }

    public class ALVehicleSpecificCard
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [Required]
        [JsonPropertyName("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [Required]
        [JsonPropertyName("VINNumber")]
        [DataMember]
        public string VINNumber { get; set; }
    }

    public class InsertALVehicleSpecificCardRequestModelOutput : BaseClassOutput
    {

    }
}
