using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class FastTagCustomerKYCModelInput:BaseClass
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
        [JsonPropertyName("AgreementWithBank")]
        [DataMember]
        public IFormFile AgreementWithBank { get; set; }

        [Required]
        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }


        [Required]
        [JsonPropertyName("AddressProofType")]
        [DataMember]
        public int AddressProofType { get; set; }


        [Required]
        [JsonPropertyName("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }


        [Required]
        [JsonPropertyName("PANCardOfFirm")]
        [DataMember]
        public IFormFile PANCardOfFirm { get; set; }

        [Required]
        [JsonPropertyName("IncorporationProof")]
        [DataMember]
        public IFormFile IncorporationProof { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class FastTagCustomerKYCModelOutput : BaseClassOutput
    {

    }
}
