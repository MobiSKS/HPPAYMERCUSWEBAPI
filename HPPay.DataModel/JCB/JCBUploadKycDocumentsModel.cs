using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    internal class JCBUploadKycDocumentsModel
    {
    }

    public class GetJCBUploadKycDocumentsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
    public class GetJCBUploadKycDocumentsModelOutput : BaseClassOutput
    {
        [JsonProperty("IdProofType")]
        [DataMember]
        public string IdProofType { get; set; }

        [JsonProperty("IdProofName")]
        [DataMember]
        public string IdProofName { get; set; }

        [JsonProperty("IdProof")]
        [DataMember]
        public string IdProof { get; set; }

        [JsonProperty("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }

        [JsonProperty("AddressProof")]
        [DataMember]
        public string AddressProof { get; set; }

        [JsonProperty("PanCardType")]
        [DataMember]
        public string PanCardType { get; set; }

        [JsonProperty("PanCard")]
        [DataMember]
        public string PanCard { get; set; }


    }


    public class InsertJCBCustomerKYCModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        //[Required]
        //[JsonPropertyName("IdProofType")]
        //[DataMember]
        //public int IdProofType { get; set; }

        [JsonPropertyName("IdProof")]
        [DataMember]
        public IFormFile IdProof { get; set; }

        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }

        [JsonPropertyName("PanCardProof")]
        [DataMember]
        public IFormFile PanCardProof { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


    }
    public class InsertJCBCustomerKYCModelOutput : BaseClassOutput
    {
    }
}
