using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALCustomerKYCModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        [Required]
        public string CustomerId { get; set; }
    }

    public class GetALCustomerKYCModelOutput : BaseClassOutput
    {


        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }

        [JsonProperty("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }

        [JsonProperty("AddressProofFront")]
        [DataMember]
        public string AddressProofFront { get; set; }

        [JsonProperty("IdProofType")]
        [DataMember]
        public string IdProofType { get; set; }

        [JsonProperty("IdProofFront")]
        [DataMember]
        public string IdProofFront { get; set; }

        [JsonProperty("PanCardType")]
        [DataMember]
        public string PanCardType { get; set; }

        [JsonProperty("PanCard")]
        [DataMember]
        public string PanCard { get; set; }

        [JsonProperty("SignedCustomerFormType")]
        [DataMember]
        public string SignedCustomerFormType { get; set; }

        [JsonProperty("SignedCustomerForm")]
        [DataMember]
        public string SignedCustomerForm { get; set; }

        [JsonProperty("VehicleDetailsType")]
        [DataMember]
        public string VehicleDetailsType { get; set; }

        [JsonProperty("VehicleDetailProof")]
        [DataMember]
        public string VehicleDetailProof { get; set; }





    }
}
