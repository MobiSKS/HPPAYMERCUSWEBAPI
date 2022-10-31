using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALUploadKycDocumentsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
    public class GetALUploadKycDocumentsModelOutput : BaseClassOutput
    {
        [JsonProperty("IdProofType")]
        [DataMember]
        public string IdProofType { get; set; }

        [JsonProperty("IdProofFront")]
        [DataMember]
        public string IdProofFront { get; set; }

        [JsonProperty("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }
        [JsonProperty("AddressProofName")]
        [DataMember]
        public string AddressProofName { get; set; }

        [JsonProperty("AddressProofFront")]
        [DataMember]
        public string AddressProofFront { get; set; }

        [JsonProperty("PanCardType")]
        [DataMember]
        public string PanCardType { get; set; }

        [JsonProperty("PanCardProofName")]
        [DataMember]
        public string PanCardProofName { get; set; }

        [JsonProperty("PanCardFront")]
        [DataMember]
        public string PanCardFront { get; set; }

        [JsonProperty("VehicleDetailsType")]
        [DataMember]
        public string VehicleDetailsType { get; set; }

        [JsonProperty("VehicleProofName")]
        [DataMember]
        public string VehicleProofName { get; set; }

        [JsonProperty("VehicleDetailsFront")]
        [DataMember]
        public string VehicleDetailsFront { get; set; }

        [JsonProperty("CustomerFormType")]
        [DataMember]
        public string CustomerFormType { get; set; }
        [JsonProperty("CustomerFormProofName")]
        [DataMember]
        public string CustomerFormProofName { get; set; }

        [JsonProperty("CustomerFormProofFront")]
        [DataMember]
        public string CustomerFormProofFront { get; set; }
        
    }

}
