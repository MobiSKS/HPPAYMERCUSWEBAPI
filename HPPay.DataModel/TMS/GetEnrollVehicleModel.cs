using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.TMS
{
    public class GetEnrollVehicleModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("EnrollmentStatus")]
        [DataMember]
        public string EnrollmentStatus { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class GetEnrollVehicleModelOutput
    {
        [JsonProperty("ObjGetEnrollVehicle")]
        public List<GetStatusEnrollVehicleModelOutput> ObjGetEnrollVehicle { get; set; }

        [JsonProperty("ObjGetEnrollVehicleCustomerName")]
        public List<GetEnrollVehicleCustomerNameModelOutput> ObjGetEnrollVehicleCustomerName { get; set; }

    }
    public class GetStatusEnrollVehicleModelOutput
    {
        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class GetEnrollVehicleCustomerNameModelOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }       
    }
}
