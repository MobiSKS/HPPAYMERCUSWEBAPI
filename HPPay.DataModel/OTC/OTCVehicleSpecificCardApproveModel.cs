using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.OTC
{
    internal class OTCVehicleSpecificCardApproveModel
    {
    }

    public class GetOTCVehicleSpecificCardApproveModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }



    public class GetOTCVehicleSpecificCardApproveModelOutput : BaseClassOutput
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
    }

    public class ApproveOTCVehicleSpecificCardApproveModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Approvalstatus")]
        [DataMember]
        public int Approvalstatus { get; set; }
        public List<OTCVehicleSpecificCardApprove> lstVehicleSpecificCardApprove { get; set; }
    }

    public class OTCVehicleSpecificCardApprove
    {
        [Required]
        [JsonPropertyName("Id")]
        [DataMember]
        public string Id { get; set; }

        [Required]
        [JsonPropertyName("PreviousCardNo")]
        [DataMember]
        public string PreviousCardNo { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [Required]
        [JsonPropertyName("CustomerID ")]
        [DataMember]
        public string CustomerID { get; set; }

    }



    public class ApproveOTCVehicleSpecificCardApproveModelOutput : BaseClassOutput
    {

    }
}
