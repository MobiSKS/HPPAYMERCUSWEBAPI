using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerKYCModelInput : BaseClass
    {


        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("IdProofType")]
        [DataMember]
        public int IdProofType { get; set; }


        [Required]
        [JsonPropertyName("IdProofDocumentNo")]
        [DataMember]
        public string IdProofDocumentNo { get; set; }


        [Required]
        [JsonPropertyName("IdProofFront")]
        [DataMember]
        public IFormFile IdProofFront { get; set; }

        [Required]
        [JsonPropertyName("IdProofBack")]
        [DataMember]
        public IFormFile IdProofBack { get; set; }


        [Required]
        [JsonPropertyName("AddressProofType")]
        [DataMember]
        public int AddressProofType { get; set; }


        [Required]
        [JsonPropertyName("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }


        [Required]
        [JsonPropertyName("AddressProofFront")]
        [DataMember]
        public IFormFile AddressProofFront { get; set; }

        [Required]
        [JsonPropertyName("AddressProofBack")]
        [DataMember]
        public IFormFile AddressProofBack { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("LetterHead")]
        [DataMember]
        public IFormFile LetterHead { get; set; }


        [JsonPropertyName("OthersDocumentNoIDProof")]
        [DataMember]
        public string OthersDocumentNoIDProof { get; set; }

        [JsonPropertyName("OthersDocumentNoAddressProof")]
        [DataMember]
        public string OthersDocumentNoAddressProof { get; set; }
    }

    public class CustomerKYCModelOutput : BaseClassOutput
    {

    }
}
